using System.Diagnostics;
using System.IO;
using System.MemoryInteraction;
using System.Text;

namespace Trion_Injector.InjectionType
{
    internal class LoadLibrary:IInjector
    {
        public ReturnCode Injecting(string dllName, string path, string exportName, Process process, MemoryManager memoryManager)
        {
            bool export = string.IsNullOrWhiteSpace(exportName);
            Executor executor = memoryManager.GetExecutor();

            if (!File.Exists(path)) return ReturnCode.FILE_NOT_FOUND;

            byte[] pathBytes = Encoding.Unicode.GetBytes(path);

            if (!executor.CallFunction(Executor.GetFunction("kernel32.dll", "LoadLibraryW"), pathBytes)) return ReturnCode.INJECTING_ERROR;

            if (!export)
            {
                ReturnCode exportCode = InjectHelper.CallExportFunction(dllName, exportName, process, executor);

                if (exportCode == ReturnCode.EXPORT_FUNCTION_ERROR || exportCode == ReturnCode.CALL_FUNCTION_ERROR) return exportCode;
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }
    }
}