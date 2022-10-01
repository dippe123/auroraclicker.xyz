using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

using static destruct.MemoryCleaner;
using static helpers.WinAPI;

namespace destruct {
    class Destruct {
        public static void InitDestruct( ) {
            try {
                DnsFlushResolverCache( );
                RegeditCleaner.Clean( );
                pcaClient_Clean( );
                GC.Collect( );
                Process.GetCurrentProcess( ).Kill( );
                Application.Exit( );
            } catch { }
        }
    }
}
