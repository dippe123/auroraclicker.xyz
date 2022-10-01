using System;
using System.Reflection;
using System.Text;

namespace destruct {
    public static class MemoryCleaner {
        public static void pcaClient_Clean( ) {
            try {
                DotNetScanMemory_SmoLL dn = new DotNetScanMemory_SmoLL( );
                string ToDeletePCA = $"TRACE,0000,0000,PcaClient,MonitorProcess,{ Assembly.GetEntryAssembly( ).Location },Time,0";
                string ArrayPCA = BitConverter.ToString( Encoding.ASCII.GetBytes( ToDeletePCA ) ).Replace( "-" , " " );
                IntPtr [ ] addressesPCA = dn.ScanArray( dn.GetPID( "explorer" ) , ArrayPCA );
                byte [ ] bufferPCA = new byte [ ArrayPCA.Length + 9 ];
                for ( int i = 0 ; i < addressesPCA.Length ; i++ ) {
                    dn.WriteArray( addressesPCA [ i ] , BitConverter.ToString( bufferPCA ).Replace( "-" , " " ) );
                }
            } catch { }
        }
    }
}
