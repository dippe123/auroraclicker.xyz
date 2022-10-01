using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using static helpers.WinAPI;

namespace checks {
    class AntiDebugger {
        public static void DebugInit( ) {
            if ( isDebugging( ) ) {
                goBSoD( );
            }
        }
        public static bool isDebugging( ) {
            if ( IsDebuggerPresent( ) )
                return true;
            if ( CheckRemoteDebugger( ) )
                return true;
            if ( CloseHandleAntiDebug( ) )
                return true;
            return false;
        }
        private static bool CheckRemoteDebugger( ) {
            bool isDebugging = false;
            CheckRemoteDebuggerPresent( Process.GetCurrentProcess( ).Handle , ref isDebugging );
            if ( isDebugging )
                return true;
            return false;
        }
        public static void TestOllyDbgExploit( ) {
            OutputDebugStringA( "%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%s%" );
        }
        public static bool CloseHandleAntiDebug( ) {
            try {
                CloseHandle( ( IntPtr ) 0xD99121L );
                return false;
            } catch ( Exception ex ) {
                if ( ex.Message == "External component has thrown an exception." ) {
                    return true;
                }
            }
            return false;
        }
        public static void HideThreadsFromDebugger( ) {
            var ProcThreads = Process.GetCurrentProcess( ).Threads;
            foreach ( ProcessThread ThreadsInProc in ProcThreads ) {
                IntPtr ThreadsHandle = OpenThread( 0x0020 , false , ( uint ) ThreadsInProc.Id );
                NtSetInformationThread( ThreadsHandle , 0x11 , IntPtr.Zero , 0 );
            }
        }
        public static void PatchingDbgUiRemoteBreakin( ) {
            IntPtr NtdllModule = GetModuleHandle( "ntdll.dll" );
            IntPtr DbgUiRemoteBreakinAddress = GetProcAddress( NtdllModule , "DbgUiRemoteBreakin" );
            byte [ ] Int3InvaildCode = { 0xCC };
            WriteProcessMemory( Process.GetCurrentProcess( ).Handle , DbgUiRemoteBreakinAddress , Int3InvaildCode , 1 , 0 );
        }
        public static void goBSoD( ) {
            Process.EnterDebugMode( );
            int status = 1;
            NtSetInformationProcess( Process.GetCurrentProcess( ).Handle , 0x1D , ref status , sizeof( int ) );
            Process.GetCurrentProcess( ).Kill( );
        }
    }
}
