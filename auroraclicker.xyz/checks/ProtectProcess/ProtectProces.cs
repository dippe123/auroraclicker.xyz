using System;
using System.Security.AccessControl;
using System.ComponentModel;
using System.Security.Principal;

using static helpers.WinAPI;
using static helpers.WinStructs;

namespace checks {
    internal class ProtectProces {
        private static protected RawSecurityDescriptor GetProcessSecurityDescriptor( IntPtr procHandle ) {
            const int DACL_SECURITY_INFORMATION = 0x00000004;
            byte [ ] b = new byte [ 0 ];
            uint bufSize;
            GetKernelObjectSecurity( procHandle , DACL_SECURITY_INFORMATION , b , 0 , out bufSize );
            if ( bufSize < 0 || bufSize > short.MaxValue )
                throw new Win32Exception( );
            if ( !GetKernelObjectSecurity( procHandle , DACL_SECURITY_INFORMATION ,
            b = new byte [ bufSize ] , bufSize , out bufSize ) )
                throw new Win32Exception( );
            return new RawSecurityDescriptor( b , 0 );
        }
        private static void SetProcessSecurityDescriptor( IntPtr procHandle , RawSecurityDescriptor dacl ) {
            const int DACL_SECURITY_INFORMATION = 0x00000004;
            byte [ ] rawsd = new byte [ dacl.BinaryLength ];
            dacl.GetBinaryForm( rawsd , 0 );
            if ( !SetKernelObjectSecurity( procHandle , DACL_SECURITY_INFORMATION , rawsd ) )
                throw new Win32Exception( );
        }
        public static void ProtectProcess( ) {
            IntPtr hProcess = GetCurrentProcess( );
            var dacl = GetProcessSecurityDescriptor( hProcess );
            dacl.DiscretionaryAcl.InsertAce( 0 , new CommonAce( AceFlags.None , AceQualifier.AccessDenied , ( int ) ProcessAccessRights.PROCESS_ALL_ACCESS , new SecurityIdentifier( WellKnownSidType.WorldSid , null ) , false , null ) );
            SetProcessSecurityDescriptor( hProcess , dacl );
        }
    }
}
