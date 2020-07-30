﻿namespace Trion_Injector.InjectionType
{
    internal enum ReturnCode
    {
        INJECTION_SUCCESSFUL,

        FILE_NOT_FOUND,
        INJECTOR_NOT_FOUND,
        PROCESS_NOT_FOUND,
        EXPORT_LIBRARY_NOT_FOUND,
        EXPORT_FUNCTION_ERROR,

        LOAD_LIBRARY_ERROR,
        INJECTING_ERROR,
        OPEN_PROCESS_ERROR,
        ALLOCATION_MEMORY_ERROR,
        WRITE_LIBRARY_ERROR,
        CALL_FUNCTION_ERROR,
        VIRTUAL_FREE_ERROR,
        CLOSE_HANDLE_ERROR,
        FREE_LIBRARY_ERROR
    }
}