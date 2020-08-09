using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                if (procAddress == IntPtr.Zero)
                {
                    return ReturnCode.EXPORT_FUNCTION_ERROR;
                }

                if (!executor.Execute(procAddress, IntPtr.Zero))
                {
                    return ReturnCode.CALL_FUNCTION_ERROR;
                }
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }

        public static unsafe string[] GetExportFunctions(IntPtr hModule)
        {
            ModuleFunctionCollection moduleFunction = Process.GetCurrentProcess().GetModuleFunctions(hModule);

            List<string> functionName = new List<string>(moduleFunction.Count);
            functionName.Add(string.Empty);

            foreach (ModuleFunction function in moduleFunction)
            {
                functionName.Add(function.Name);
            }

            return functionName.ToArray();
        }
    }
}