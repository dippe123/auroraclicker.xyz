using Microsoft.Win32;

namespace destruct {
    class RegeditCleaner {

        private static string [ ] CurrentUserKeys = new string [ ] {
            "SOFTWARE\\MICROSOFT\\WINDOWS\\SHELL\\",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\SHELLNOROAM\\",

            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\COMDLG32\\",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\UserAssist",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\FeatureUsage\\AppSwitched",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Internet Settings\\5.0\\Cache\\History\\",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\ComDlg32\\OpenSavePidlMRU\\*",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\ComDlg32\\OpenSavePidlMRU\\exe",
            "SOFTWARE\\MICROSOFT\\WINDOWS\\CURRENTVERSION\\Explorer\\ComDlg32\\LastVisitedPidlMRU",

            "SOFTWARE\\CLASSES\\LOCAL SETTINGS\\SOFTWARE\\MICROSOFT\\WINDOWS\\SHELL\\",

            "SOFTWARE\\MICROSOFT\\WINDOWS NT\\CURRENTVERSION\\APPCOMPATFLAGS\\COMPATIBILITY ASSISTANT\\",
            "SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\CurrentVersion\\AppContainer\\Storage\\"
        };

        public static void Clean( ) {
            try {
                foreach ( var key in CurrentUserKeys )
                    CleanRegedit( key , Registry.CurrentUser );
                CleanRegedit( "SYSTEM\\ControlSet001\\Services\\bam\\State\\" , Registry.LocalMachine );
            } catch { }
        }

        public static void CleanRegedit( string path , RegistryKey registryKey ) {
            try {
                using ( var key = registryKey.OpenSubKey( path , true ) ) {
                    foreach ( var c in key.GetSubKeyNames( ) ) {
                        var pkey = key.OpenSubKey( c );
                        pkey.DeleteSubKeyTree( c );
                    }
                }
            } catch { }
        }
    }
}
