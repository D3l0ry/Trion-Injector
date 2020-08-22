using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.MemoryInteraction;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.ProcessExtensions;

namespace Trion_Injector.InjectionType
{
    class ManualMap : IInjector
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr fnLoadLibrary(string dllName);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr fnGetProcAddress(IntPtr hModule, string procName);

        private struct Loader
        {
            public fnGetProcAddress pGetProcAddress;
            public fnLoadLibrary pLoadLibrary;
        }

        private void ShellCode(ref Loader p)
        {
            fnLoadLibrary pLoadLibrary = p.pLoadLibrary;
            fnGetProcAddress pGetProcAddress = p.pGetProcAddress;
        }

        public ReturnCode Injecting(string dllName, string path, string exportName, Process process, MemoryManager memoryManager)
        {
            return ReturnCode.INJECTION_SUCCESSFUL;
        }
    }
}