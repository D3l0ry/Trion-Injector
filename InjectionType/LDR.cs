using System;
using System.Diagnostics;
using System.IO;
using System.MemoryInteraction;
using System.Text;
using System.WinApi;

namespace Trion_Injector.InjectionType
{
    internal class LDR:IInjector
    {
        #region Public Methods
        public ReturnCode Injecting(string dllName, string path, string exportName, Process process, MemoryManager memoryManager)
        {
            IntPtr hModule = IntPtr.Zero;
            bool export = string.IsNullOrWhiteSpace(exportName);
            IAllocator allocator = memoryManager.GetAllocator();
            Executor executor = memoryManager.GetExecutor();

            if (!File.Exists(path))
            {
                return ReturnCode.FILE_NOT_FOUND;
            }

            if (!export)
            {
               hModule = Kernel32.LoadLibrary(path);
            }

            byte[] pathBytes = Encoding.Unicode.GetBytes(path);

            IntPtr AllocationMemory = allocator.Alloc(pathBytes.Length);
            if (AllocationMemory == IntPtr.Zero)
            {
                return ReturnCode.ALLOCATION_MEMORY_ERROR;
            }

            if (!memoryManager.BlockCopy(pathBytes, 0, AllocationMemory, 0, (IntPtr)pathBytes.Length))
            {
                return ReturnCode.WRITE_LIBRARY_ERROR;
            }

            if (!executor.Execute(executor.GetFunction("kernel32.dll","LoadLibraryW"), AllocationMemory))
            {
                return ReturnCode.INJECTING_ERROR;
            }

            allocator.Free(AllocationMemory);

            if (!export)
            {
                ReturnCode exportCode = InjectHelper.CallExportFunction(dllName, exportName, process, executor);

                if (exportCode == ReturnCode.EXPORT_FUNCTION_ERROR || exportCode == ReturnCode.CALL_FUNCTION_ERROR)
                {
                    return exportCode;
                }
            }

            if(!export)
            {
                Kernel32.FreeLibrary(hModule);
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }
        #endregion
    }
}