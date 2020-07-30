using System;
using System.Diagnostics;
using System.IO;
using System.MemoryInteraction;
using System.Reflection;
using System.Text;

namespace Trion_Injector.InjectionType
{
    internal class LDR:IInjector
    {
        #region Public Methods
        public ReturnCode Injecting(string dllName, string path, string exportName, Process process, MemoryManager memoryManager)
        {
            bool export = string.IsNullOrWhiteSpace(exportName);
            IAllocator allocator = memoryManager.GetAllocator();
            Executor executor = memoryManager.GetExecutor();

            if (!File.Exists(path))
            {
                return ReturnCode.FILE_NOT_FOUND;
            }

            if (!export)
            {
                Assembly.LoadFrom(path);
            }

            IntPtr AllocationMemory = allocator.Alloc(dllName.Length + 1);
            if (AllocationMemory == IntPtr.Zero)
            {
                return ReturnCode.ALLOCATION_MEMORY_ERROR;
            }

            if (!memoryManager.BlockCopy(Encoding.UTF8.GetBytes(path), 0, AllocationMemory, 0, (IntPtr)path.Length))
            {
                return ReturnCode.WRITE_LIBRARY_ERROR;
            }

            if (!executor.Execute(executor.GetFunction("kernel32.dll","LoadLibraryA"), AllocationMemory))
            {
                return ReturnCode.INJECTING_ERROR;
            }

            allocator.Free(AllocationMemory);

            if (!export)
            {
                InjectHelper.CallExportFunction(dllName, exportName, process, executor);
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }
        #endregion
    }
}