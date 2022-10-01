using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using static checks.InitChecks;
namespace auroraas_recodes {
    static class Program {
        [DllImport( "kernel32.dll" , SetLastError = true )] internal static extern int FreeConsole( );
        static Mutex mamt = new Mutex( false , "aurora" );
        [STAThread]
        static void Main( ) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if ( !mamt.WaitOne( 0 , false ) )
                return;
            Checks( );
            FreeConsole( );
            Application.EnableVisualStyles( );
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new LoginForm( ) );
            GC.Collect( );
        }
    }
}


