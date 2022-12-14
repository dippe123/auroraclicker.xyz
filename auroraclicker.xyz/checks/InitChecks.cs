namespace checks {
    class InitChecks {
        public static void Checks( ) {
            AntiDumper.Init( );
            BetterAntiDump.BetterAntiDumper( );
            ProcessScan.Init( );
            AntiHooks.InitAntiHooker( );
            AntiDebugger.DebugInit( );
            AntiDebugger.TestOllyDbgExploit( );
            AntiDebugger.PatchingDbgUiRemoteBreakin( );
            AntiDebugger.HideThreadsFromDebugger( );
            Emulation.Init( );
            Emulation.SandBoxCrash( );
            ProtectProces.ProtectProcess( );
        }
    }
}
