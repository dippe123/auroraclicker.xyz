﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace helpers {
    class WinStructs {
        public enum PROCESSINFOCLASS:int {
            ProcessBasicInformation,
            ProcessQuotaLimits,
            ProcessIoCounters, 
            ProcessVmCounters,
            ProcessTimes, 
            ProcessBasePriority, 
            ProcessRaisePriority, 
            ProcessDebugPort, 
            ProcessExceptionPort, 
            ProcessAccessToken,
            ProcessLdtInformation, 
            ProcessLdtSize,
            ProcessDefaultHardErrorMode, 
            ProcessIoPortHandlers, 
            ProcessPooledUsageAndLimits, 
            ProcessWorkingSetWatch,
            ProcessUserModeIOPL,
            ProcessEnableAlignmentFaultFixup, 
            ProcessPriorityClass, 
            ProcessWx86Information,
            ProcessHandleCount, 
            ProcessAffinityMask, 
            ProcessPriorityBoost, 
            ProcessDeviceMap, 
            ProcessSessionInformation, 
            ProcessForegroundInformation, 
            ProcessWow64Information, 
            ProcessImageFileName, 
            ProcessLUIDDeviceMapsEnabled, 
            ProcessBreakOnTermination, 
            ProcessDebugObjectHandle, 
            ProcessDebugFlags, 
            ProcessHandleTracing,
            ProcessIoPriority, 
            ProcessExecuteFlags, 
            ProcessResourceManagement,
            ProcessCookie,
            ProcessImageInformation, 
            ProcessCycleTime, 
            ProcessPagePriority, 
            ProcessInstrumentationCallback, 
            ProcessThreadStackAllocation, 
            ProcessWorkingSetWatchEx, 
            ProcessImageFileNameWin32,
            ProcessImageFileMapping, 
            ProcessAffinityUpdateMode,
            ProcessMemoryAllocationMode, 
            ProcessGroupInformation, 
            ProcessTokenVirtualizationEnabled, 
            ProcessConsoleHostProcess, 
            ProcessWindowInformation, 
            ProcessHandleInformation,
            ProcessMitigationPolicy, 
            ProcessDynamicFunctionTableInformation,
            ProcessHandleCheckingMode,
            ProcessKeepAliveCount, 
            ProcessRevokeFileHandles, 
            ProcessWorkingSetControl, 
            ProcessHandleTable, 
            ProcessCheckStackExtentsMode,
            ProcessCommandLineInformation, 
            ProcessProtectionInformation,
            MaxProcessInfoClass
        }

        [Flags]
        public enum DebugObjectInformationClass:int {
            DebugObjectFlags = 1,
            MaxDebugObjectInfoClass
        }

        public enum SYSTEM_INFORMATION_CLASS {
            SystemBasicInformation, 
            SystemProcessorInformation,
            SystemPerformanceInformation, 
            SystemTimeOfDayInformation,
            SystemPathInformation, 
            SystemProcessInformation, 
            SystemCallCountInformation, 
            SystemDeviceInformation, 
            SystemProcessorPerformanceInformation, 
            SystemFlagsInformation, 
            SystemCallTimeInformation, 
            SystemModuleInformation, 
            SystemLocksInformation,
            SystemStackTraceInformation,
            SystemPagedPoolInformation, 
            SystemNonPagedPoolInformation, 
            SystemHandleInformation, 
            SystemObjectInformation, 
            SystemPageFileInformation, 
            SystemVdmInstemulInformation,
            SystemVdmBopInformation,
            SystemFileCacheInformation, 
            SystemPoolTagInformation, 
            SystemInterruptInformation, 
            SystemDpcBehaviorInformation, 
            SystemFullMemoryInformation,
            SystemLoadGdiDriverInformation, 
            SystemUnloadGdiDriverInformation, 
            SystemTimeAdjustmentInformation,
            SystemSummaryMemoryInformation, 
            SystemMirrorMemoryInformation,
            SystemPerformanceTraceInformation, 
            SystemObsolete0,
            SystemExceptionInformation, 
            SystemCrashDumpStateInformation, 
            SystemKernelDebuggerInformation, 
            SystemContextSwitchInformation, 
            SystemRegistryQuotaInformation, 
            SystemExtendServiceTableInformation, 
            SystemPrioritySeperation, 
            SystemVerifierAddDriverInformation, 
            SystemVerifierRemoveDriverInformation, 
            SystemProcessorIdleInformation, 
            SystemLegacyDriverInformation, 
            SystemCurrentTimeZoneInformation,
            SystemLookasideInformation, 
            SystemTimeSlipNotification,
            SystemSessionCreate,
            SystemSessionDetach,
            SystemSessionInformation, 
            SystemRangeStartInformation, 
            SystemVerifierInformation, 
            SystemVerifierThunkExtend, 
            SystemSessionProcessInformation, 
            SystemLoadGdiDriverInSystemSpace, 
            SystemNumaProcessorMap, 
            SystemPrefetcherInformation,
            SystemExtendedProcessInformation, 
            SystemRecommendedSharedDataAlignment, 
            SystemComPlusPackage, 
            SystemNumaAvailableMemory, 
            SystemProcessorPowerInformation, 
            SystemEmulationBasicInformation, 
            SystemEmulationProcessorInformation,
            SystemExtendedHandleInformation, 
            SystemLostDelayedWriteInformation, 
            SystemBigPoolInformation, 
            SystemSessionPoolTagInformation, 
            SystemSessionMappedViewInformation, 
            SystemHotpatchInformation, 
            SystemObjectSecurityMode, 
            SystemWatchdogTimerHandler,
            SystemWatchdogTimerInformation, 
            SystemLogicalProcessorInformation,
            SystemWow64SharedInformationObsolete, 
            SystemRegisterFirmwareTableInformationHandler, 
            SystemFirmwareTableInformation, 
            SystemModuleInformationEx, 
            SystemVerifierTriageInformation, 
            SystemSuperfetchInformation, 
            SystemMemoryListInformation,    
            SystemFileCacheInformationEx,  
            SystemThreadPriorityClientIdInformation, 
            SystemProcessorIdleCycleTimeInformation, 
            SystemVerifierCancellationInformation, 
            SystemProcessorPowerInformationEx, 
            SystemRefTraceInformation, 
            SystemSpecialPoolInformation,
            SystemProcessIdInformation, 
            SystemErrorPortInformation, 
            SystemBootEnvironmentInformation, 
            SystemHypervisorInformation, 
            SystemVerifierInformationEx, 
            SystemTimeZoneInformation, 
            SystemImageFileExecutionOptionsInformation, 
            SystemCoverageInformation,
            SystemPrefetchPatchInformation,
            SystemVerifierFaultsInformation, 
            SystemSystemPartitionInformation,
            SystemSystemDiskInformation,
            SystemProcessorPerformanceDistribution,
            SystemNumaProximityNodeInformation, 
            SystemDynamicTimeZoneInformation, 
            SystemCodeIntegrityInformation, 
            SystemProcessorMicrocodeUpdateInformation, 
            SystemProcessorBrandString,
            SystemVirtualAddressInformation,        
            SystemLogicalProcessorAndGroupInformation, 
            SystemProcessorCycleTimeInformation, 
            SystemStoreInformation, 
            SystemRegistryAppendString, 
            SystemAitSamplingValue, 
            SystemVhdBootInformation, 
            SystemCpuQuotaInformation, 
            SystemNativeBasicInformation, 
            SystemSpare1,
            SystemLowPriorityIoInformation,
            SystemTpmBootEntropyInformation,
            SystemVerifierCountersInformation,
            SystemPagedPoolInformationEx,
            SystemSystemPtesInformationEx,
            SystemNodeDistanceInformation,
            SystemAcpiAuditInformation,
            SystemBasicPerformanceInformation,
            SystemQueryPerformanceCounterInformation,
            SystemSessionBigPoolInformation,
            SystemBootGraphicsInformation,
            SystemScrubPhysicalMemoryInformation,
            SystemBadPageInformation,
            SystemProcessorProfileControlArea,
            SystemCombinePhysicalMemoryInformation,
            SystemEntropyInterruptTimingCallback,
            SystemConsoleInformation,
            SystemPlatformBinaryInformation,
            SystemThrottleNotificationInformation,
            SystemHypervisorProcessorCountInformation,
            SystemDeviceDataInformation,
            SystemDeviceDataEnumerationInformation,
            SystemMemoryTopologyInformation,
            SystemMemoryChannelInformation,
            SystemBootLogoInformation,
            SystemProcessorPerformanceInformationEx,
            SystemSpare0,
            SystemSecureBootPolicyInformation,
            SystemPageFileInformationEx,
            SystemSecureBootInformation,
            SystemEntropyInterruptTimingRawInformation,
            SystemPortableWorkspaceEfiLauncherInformation,
            SystemFullProcessInformation,
            SystemKernelDebuggerInformationEx,
            SystemBootMetadataInformation,
            SystemSoftRebootInformation,
            SystemElamCertificateInformation,
            SystemOfflineDumpConfigInformation,
            SystemProcessorFeaturesInformation,
            SystemRegistryReconciliationInformation,
            SystemEdidInformation,
            MaxSystemInfoClass
        }

        public enum ThreadInformationClass {
            ThreadBasicInformation = 0,
            ThreadTimes = 1,
            ThreadPriority = 2,
            ThreadBasePriority = 3,
            ThreadAffinityMask = 4,
            ThreadImpersonationToken = 5,
            ThreadDescriptorTableEntry = 6,
            ThreadEnableAlignmentFaultFixup = 7,
            ThreadEventPair_Reusable = 8,
            ThreadQuerySetWin32StartAddress = 9,
            ThreadZeroTlsCell = 10,
            ThreadPerformanceCount = 11,
            ThreadAmILastThread = 12,
            ThreadIdealProcessor = 13,
            ThreadPriorityBoost = 14,
            ThreadSetTlsArrayAddress = 15,   
            ThreadIsIoPending = 16,
            ThreadHideFromDebugger = 17,
            ThreadBreakOnTermination = 18,
            ThreadSwitchLegacyState = 19,
            ThreadIsTerminated = 20,
            ThreadLastSystemCall = 21,
            ThreadIoPriority = 22,
            ThreadCycleTime = 23,
            ThreadPagePriority = 24,
            ThreadActualBasePriority = 25,
            ThreadTebInformation = 26,
            ThreadCSwitchMon = 27,  
            ThreadCSwitchPmu = 28,
            ThreadWow64Context = 29,
            ThreadGroupInformation = 30,
            ThreadUmsInformation = 31,   
            ThreadCounterProfiling = 32,
            ThreadIdealProcessorEx = 33,
            ThreadCpuAccountingInformation = 34,
            ThreadSuspendCount = 35,
            ThreadDescription = 38,
            ThreadActualGroupAffinity = 41,
            ThreadDynamicCodePolicy = 42,
        }

        [Flags]
        public enum ThreadAccess:int {
            TERMINATE = ( 0x0001 ),
            SUSPEND_RESUME = ( 0x0002 ),
            GET_CONTEXT = ( 0x0008 ),
            SET_CONTEXT = ( 0x0010 ),
            SET_INFORMATION = ( 0x0020 ),
            QUERY_INFORMATION = ( 0x0040 ),
            SET_THREAD_TOKEN = ( 0x0080 ),
            IMPERSONATE = ( 0x0100 ),
            DIRECT_IMPERSONATION = ( 0x0200 )
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct SYSTEM_KERNEL_DEBUGGER_INFORMATION {
            [MarshalAs( UnmanagedType.U1 )]
            public bool KernelDebuggerEnabled;

            [MarshalAs( UnmanagedType.U1 )]
            public bool KernelDebuggerNotPresent;
        }
        [StructLayout( LayoutKind.Sequential )]
        public struct CURSORINFO {
            public int cbSize;
            public int flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct POINTAPI {
            public int x; public int y;
        }
        [Flags]
        public enum InternetConnectionState_e:int {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        [Flags]
        public enum ProcessAccessRights {
            PROCESS_CREATE_PROCESS = 0x0080, 
            PROCESS_CREATE_THREAD = 0x0002, 
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200, 
            PROCESS_SET_QUOTA = 0x0100, 
            PROCESS_SUSPEND_RESUME = 0x0800, 
            PROCESS_TERMINATE = 0x0001, 
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010, 
            PROCESS_VM_WRITE = 0x0020, 
            DELETE = 0x00010000,
            READ_CONTROL = 0x00020000,
            SYNCHRONIZE = 0x00100000, 
            WRITE_DAC = 0x00040000, 
            WRITE_OWNER = 0x00080000, 
            STANDARD_RIGHTS_REQUIRED = 0x000f0000,
            PROCESS_ALL_ACCESS = ( STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF ),
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct SystemInfo {
            public ProcessorArchitecture ProcessorArchitecture;
            public uint PageSize;
            public IntPtr MinimumApplicationAddress;
            public IntPtr MaximumApplicationAddress;
            public IntPtr ActiveProcessorMask;
            public uint NumberOfProcessors;
            public uint ProcessorType;
            public uint AllocationGranularity;
            public ushort ProcessorLevel;
            public ushort ProcessorRevision;
        }

        [StructLayout( LayoutKind.Sequential )]
        public struct MEMORY_BASIC_INFORMATION {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
    }
}
