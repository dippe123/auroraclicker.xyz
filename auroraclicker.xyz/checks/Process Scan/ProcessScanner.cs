using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

using static helpers.WinAPI;

namespace checks {
    class ProcessScan {
        private static bool _TurnedOn = false;
        private static bool _TurnedOff = false;
        private static readonly string [ ] badProcessList = { "ilspy" , "simpleassemblyexplorer" , "KsDumperClient" , "HTTPDebuggerUI" , "FolderChangesView" , "ProcessHacker" , "procmon" , "idaq" , "idaq64" , "Wireshark" , "Fiddler" , "Xenos64" , "Cheat Engine" , "HTTP Debugger Windows Service (32 bit)" , "KsDumper" , "x64dbg" , "x32dbg" , "dnspy" , "dnspy(x86)" , "charles" , "dbx" , "mdbg" , "gdb" , "windbg" , "dbgclr" , "kdb" , "kgdb" , "mdb" , "proxifier" , "mitmproxy" , "process hacker" , "process monitor" , "process hacker 2" , "system explorer" , "systemexplorer" , "systemexplorerservice" , "WPE PRO" , "Th3ken" , "scyllaHide" };
        private static readonly string [ ] DebugProcessList = { "taskkill /f /im x96dbg.exe >nul 2>&1" , "taskkill /f /im x32dbg.exe >nul 2>&1" , "taskkill /f /im x64dbg.exe >nul 2>&1" , "taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1" , "taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1" , "sc stop HTTPDebuggerPro >nul 2>&1" , "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq wireshark*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq rawshark*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq charles*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq ida*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1" , "taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1" , "sc stop HTTPDebuggerPro >nul 2>&1" , "sc stop KProcessHacker3 >nul 2>&1" , "sc stop KProcessHacker2 >nul 2>&1" , "sc stop KProcessHacker1 >nul 2>&1" , "sc stop wireshark >nul 2>&1" , "sc stop npf >nul 2>&1" , };

        public static void Init( ) {
            Thread pThread = new Thread( CheckBadProcess );
            pThread.Start( );
            killBadProc( );
            bModulesCheck( );
        }
        private static void CheckBadProcess( ) {
            while ( true ) {
                foreach ( string str in badProcessList ) {
                    killProcesses( str );
                    Thread.Sleep( 75 );
                }
                Thread.Sleep( 1 );
            }
        }

        private static bool killProcesses( string pname ) {
            bool pRunning = Process.GetProcessesByName( pname ).Any( );

            if ( pRunning ) {
                Process p = Process.GetProcessesByName( pname ).FirstOrDefault( );
                try { p.Kill( ); Freeze_Mouse( ); explorer_Restart( );  Environment.Exit( 1 ); } catch { }
            }

            return pRunning;
        }
        public static void bModulesCheck( ) {
            if ( GetModuleHandle( "HTTPDebuggerBrowser.dll" ) != IntPtr.Zero || GetModuleHandle( "FiddlerCore4.dll" ) != IntPtr.Zero || GetModuleHandle( "Titanium.Web.Proxy.dll" ) != IntPtr.Zero ) {
                Environment.Exit( -1 );
            }
        }
        private static void killBadProc( ) {
            foreach ( string str in DebugProcessList )
                CommandLine( str );
        }
        private static void CommandLine( string command ) {
            Process.Start( new ProcessStartInfo( "cmd.exe" ) {
                CreateNoWindow = true ,
                WindowStyle = ProcessWindowStyle.Hidden ,
                Arguments = "/C " + command
            } );
        }
        public static void explorer_Restart( ) {
            Process.Start( "C:\\Windows\\System32\\taskkill.exe" , "/F /IM explorer.exe" );
            Thread.Sleep( 2000 );
            Process.Start( Path.Combine( Environment.GetEnvironmentVariable( "windir" ) , "explorer.exe" ) );
        }
        private static void Freeze_Mouse( ) {
            _TurnedOn = true;
            _TurnedOff = false;
            Thread KillDirectory = new Thread( FreezeWindowsProcess );
            KillDirectory.Start( );
            Thread.Sleep( 2000 );
            _TurnedOn = false;
            _TurnedOff = true;
            BlockInput( false );
        }
        private static void FreezeWindowsProcess( ) {
            while ( _TurnedOn ) {
                BlockInput( true );
            }
            while ( _TurnedOff ) {
                BlockInput( false );
            }
            Thread.Sleep( 250 );
        }
    }
}
