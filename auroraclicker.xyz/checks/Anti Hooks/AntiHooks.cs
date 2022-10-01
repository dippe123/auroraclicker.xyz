using helpers;
using System;
using System.Diagnostics;

namespace checks {
    internal class AntiHooks {
        public static void InitAntiHooker( ) {
            LoadLibraryPatch( );
            if ( isDebugged( ) )
                AntiDebugger.goBSoD( );
        }
        public static bool isDebugged( ) {
            byte [ ] bSkip = new byte [ 1 ];
            byte [ ] bMov = new byte [ 1 ] { 0x8B };
            bool isInDebugMode = false;
            IntPtr CheckRemoteDebuggerPresentAddr = MemoryStructs.GetProcAddress( MemoryStructs.GetModuleHandle( "Kernel32.dll" ) , "CheckRemoteDebuggerPresent" );
            MemoryStructs.ReadProcessMemory( Process.GetCurrentProcess( ).Handle , CheckRemoteDebuggerPresentAddr , bSkip , 2 , out _ );
            if ( !ByteArrayCompare( bSkip , bMov ) )
                isInDebugMode = true;

            return isInDebugMode;
        }
        private static bool ByteArrayCompare( byte [ ] b1 , byte [ ] b2 ) {
            return b1.Length == b2.Length && MemoryStructs.memcmp( b1 , b2 , b1.Length ) == 0;
        }
        public static void LoadLibraryPatch( ) {
            IntPtr KernelModule = WinAPI.GetModuleHandle( "kernelbase.dll" );
            IntPtr LoadLibrary = WinAPI.GetProcAddress( KernelModule , "LoadLibrary" );
            byte [ ] HookedCode = { 0xC2 , 0x04 , 0x00 };
            WinAPI.WriteProcessMemory( Process.GetCurrentProcess( ).Handle , LoadLibrary , HookedCode , 3 , 0 );
        }
    }
}
