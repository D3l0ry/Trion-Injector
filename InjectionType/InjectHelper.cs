using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.MemoryInteraction;

namespace Trion_Injector.InjectionType
{
    internal static class InjectHelper
    {
        public static ReturnCode CallExportFunction(string dllName, string exportName, Process process, Executor executor)
        {
            ProcessModule processModule = process.GetModule(dllName);
            if (processModule != null)
            {
                IntPtr procAddress = process.GetModuleFunctions(processModule.BaseAddress)[exportName].VirtualAddress;

                if (procAddress == IntPtr.Zero) return ReturnCode.EXPORT_FUNCTION_ERROR;

                if (!executor.Execute(procAddress, IntPtr.Zero)) return ReturnCode.CALL_FUNCTION_ERROR;
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }

        public static unsafe string[] GetExportFunctions(IntPtr hModule)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ModuleFunctionCollection moduleFunction = currentProcess.GetModuleFunctions(hModule);

            List<string> functionName = new List<string>(moduleFunction.Count)
            {
                ""
            };

            functionName.AddRange(moduleFunction.Cast<ModuleFunction>().Select(X => X.Name));

            currentProcess.Dispose();

            return functionName.ToArray();
        }
    }
}