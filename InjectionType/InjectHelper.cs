using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.MemoryInteraction;
using System.Runtime.InteropServices;

namespace Trion_Injector.InjectionType
{
    internal static class InjectHelper
    {
        public unsafe struct IMAGE_DOS_HEADER
        {
            short e_magic;
            short e_cblp;
            short e_cp;
            short e_crlc;
            short e_cparhdr;
            short e_minalloc;
            short e_maxalloc;
            short e_ss;
            short e_sp;
            short e_csum;
            short e_ip;
            short e_cs;
            short e_lfarlc;
            short e_ovno;
            fixed short e_res[4];
            short e_oemid;
            short e_oeminfo;
            fixed short e_res2[10];
            public short e_lfanew;
        }

        public unsafe struct IMAGE_NT_HEADERS
        {
            int Signature;
            IMAGE_FILE_HEADER FileHeader;
            public IMAGE_OPTIONAL_HEADER OptionalHeader;
        }

        public unsafe struct IMAGE_FILE_HEADER
        {
            short Machine;
            short NumberOfSection;
            int TimeDataStamp;
            int PointerToSymbolTable;
            int NumberOfSymbol;
            short SizeOfOptionalHeader;
            short Characteristics;
        }

        public unsafe struct IMAGE_OPTIONAL_HEADER
        {
            short Magic;
            byte MajorLinkedVersion;
            byte MinorLinkedVersion;
            int SizeOfCode;
            int SizeOfInitializedData;
            int SizeOfUInitializedData;
            int AddressOfEntryPoint;
            int BaseOfCode;
            int BaseOfData;
            int ImageBase;
            int SectionAlignment;
            int FileAlignment;
            short MajorOperatingSystemVersion;
            short MinororOperatingSystemVersion;
            short MajorImageVersion;
            short MinorImageVersion;
            short MajorSubsystemVersion;
            short MinorSubsystemVersion;
            int Win32VersionValue;
            int SizeOfImage;
            int SizeOfHeaders;
            int CheckSum;
            short Subsystem;
            short DllCharacteristics;
            int SizeOfStackReverse;
            int SizeOfStackCommit;
            int SizeOfHeapReserve;
            int SizeOfHeapCommit;
            int LoaderFlags;
            int NumberOfRvaAndSizes;

            public IMAGE_DATA_DIRECTORY DataDirectory;
        }

        public unsafe struct IMAGE_DATA_DIRECTORY
        {
            public int VirtualAddress;
            public int Size;
        }

        public unsafe struct IMAGE_EXPORT_DIRECTORY
        {
            int Characteristics;
            int TimeDateStamp;
            short MajorVersion;
            short MinorVersion;
            int Name;
            int Base;
            public int NumberOfFunctions;
            public int NumberOfNames;
            public int AddressOfFunctions;
            public int AddressOfNames;
            public int AddressOfNameOrdinals;
        }

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
                    return ReturnCode.CALL_FUNCTION_ERROR;
                }
            }

            return ReturnCode.INJECTION_SUCCESSFUL;
        }

        public static unsafe string[] GetExportFunctions(IntPtr hModule)
        {
            IMAGE_DOS_HEADER* dosHeader = (IMAGE_DOS_HEADER*)hModule;

            IMAGE_NT_HEADERS* ntHeader = (IMAGE_NT_HEADERS*)(hModule + dosHeader->e_lfanew);

            IMAGE_EXPORT_DIRECTORY* exportDirectory = (IMAGE_EXPORT_DIRECTORY*)(hModule + ntHeader->OptionalHeader.DataDirectory.VirtualAddress);

            List<string> functionName = new List<string>(exportDirectory->NumberOfNames);
            functionName.Add(string.Empty);

            uint* ptrNameFunction = (uint*)(hModule + exportDirectory->AddressOfNames);

            for(int index = 0; index < exportDirectory->NumberOfNames;index++)
            {
                functionName.Add(Marshal.PtrToStringAnsi((IntPtr)((uint)hModule + ptrNameFunction[index])));
            }

            return functionName.ToArray();
        }

        public static unsafe string[] GetExportFunctions(string dllName)
        {
            return GetExportFunctions(Process.GetCurrentProcess().GetModule(dllName).BaseAddress);
        }
    }
}