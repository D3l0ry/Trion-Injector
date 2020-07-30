using System;
using System.Diagnostics;
using System.MemoryInteraction;

namespace Trion_Injector.InjectionType
{
    internal static class InjectHelper
    {
        public static ReturnCode CallExportFunction(string dllName, string exportName, Process process, Executor executor)
        {
            ProcessModule ProcessModule = process.GetModule(dllName);
            if (ProcessModule != null)
            {
                IntPtr ProcAddress = executor.GetFunction(ProcessModule.BaseAddress, exportName);
                if (ProcAddress == IntPtr.Zero)
                {
                    return ReturnCode.EXPORT_FUNCTION_ERROR;
                }

                if (!executor.Execute(ProcAddress, IntPtr.Zero))
                {
                    return ReturnCode.EXPORT_FUNCTION_ERROR;
                }
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }
    }
}