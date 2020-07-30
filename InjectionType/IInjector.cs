using System.Diagnostics;
using System.MemoryInteraction;

namespace Trion_Injector.InjectionType
{
    internal interface IInjector
    {
        ReturnCode Injecting(string dllName, string path, string exportName, Process process, MemoryManager memoryManager);
    }
}