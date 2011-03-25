
//
// Copyright (c) Michael Eddington
//
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in	
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

// Authors:
//   Michael Eddington (mike@phed.org)

// $Id$

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Peach.Debuggers.DbgEng.Tlb;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics;

namespace Peach.Debuggers.DbgEng
{
	public class Const
	{
		public static int DEBUG_PROCESS = 1;
		public static int DEBUG_ONLY_THIS_PROCESS = 2;
		public static int DEBUG_GET_TEXT_COMPLETIONS_NO_DOT_COMMANDS = 1;
		public static int DEBUG_GET_TEXT_COMPLETIONS_NO_EXTENSION_COMMANDS = 2;
		public static int DEBUG_GET_TEXT_COMPLETIONS_NO_SYMBOLS = 4;
		public static int DEBUG_GET_TEXT_COMPLETIONS_IS_DOT_COMMAND = 1;
		public static int DEBUG_GET_TEXT_COMPLETIONS_IS_EXTENSION_COMMAND = 2;
		public static int DEBUG_GET_TEXT_COMPLETIONS_IS_SYMBOL = 4;
		public static int DEBUG_REQUEST_SOURCE_PATH_HAS_SOURCE_SERVER;
		public static int DEBUG_REQUEST_TARGET_EXCEPTION_CONTEXT = 1;
		public static int DEBUG_REQUEST_TARGET_EXCEPTION_THREAD = 2;
		public static int DEBUG_REQUEST_TARGET_EXCEPTION_RECORD = 3;
		public static int DEBUG_REQUEST_GET_ADDITIONAL_CREATE_OPTIONS = 4;
		public static int DEBUG_REQUEST_SET_ADDITIONAL_CREATE_OPTIONS = 5;
		public static int DEBUG_REQUEST_GET_WIN32_MAJOR_MINOR_VERSIONS = 6;
		public static int DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM = 7;
		public static int DEBUG_REQUEST_TARGET_CAN_DETACH = 8;
		public static int DEBUG_REQUEST_SET_LOCAL_IMPLICIT_COMMAND_LINE = 9;
		public static int DEBUG_REQUEST_GET_CAPTURED_EVENT_CODE_OFFSET = 10;
		public static int DEBUG_REQUEST_READ_CAPTURED_EVENT_CODE_STREAM = 11;
		public static int DEBUG_REQUEST_EXT_TYPED_DATA_ANSI = 12;
		public static int DEBUG_REQUEST_GET_EXTENSION_SEARCH_PATH_WIDE = 13;
		public static int DEBUG_REQUEST_GET_TEXT_COMPLETIONS_WIDE = 14;
		public static int DEBUG_REQUEST_GET_CACHED_SYMBOL_INFO = 15;
		public static int DEBUG_REQUEST_ADD_CACHED_SYMBOL_INFO = 0x10;
		public static int DEBUG_REQUEST_REMOVE_CACHED_SYMBOL_INFO = 0x11;
		public static int DEBUG_REQUEST_GET_TEXT_COMPLETIONS_ANSI = 0x12;
		public static int DEBUG_REQUEST_CURRENT_OUTPUT_CALLBACKS_ARE_DML_AWARE = 0x13;
		public static int DEBUG_SRCFILE_SYMBOL_TOKEN;
		public static int DEBUG_SRCFILE_SYMBOL_TOKEN_SOURCE_COMMAND_WIDE = 1;
		public static int DEBUG_SYMINFO_BREAKPOINT_SOURCE_LINE;
		public static int DEBUG_SYMINFO_IMAGEHLP_MODULEW64 = 1;
		public static int DEBUG_SYMINFO_GET_SYMBOL_NAME_BY_OFFSET_AND_TAG_WIDE = 2;
		public static int DEBUG_SYMINFO_GET_MODULE_SYMBOL_NAMES_AND_OFFSETS = 3;
		public static int DEBUG_SYSOBJINFO_THREAD_BASIC_INFORMATION;
		public static int DEBUG_SYSOBJINFO_THREAD_NAME_WIDE = 1;
		public static int DEBUG_SYSOBJINFO_CURRENT_PROCESS_COOKIE = 2;
		public static int DEBUG_TBINFO_EXIT_STATUS = 1;
		public static int DEBUG_TBINFO_PRIORITY_CLASS = 2;
		public static int DEBUG_TBINFO_PRIORITY = 4;
		public static int DEBUG_TBINFO_TIMES = 8;
		public static int DEBUG_TBINFO_START_OFFSET = 0x10;
		public static int DEBUG_TBINFO_AFFINITY = 0x20;
		public static int DEBUG_TBINFO_ALL = 0x3f;
		public static int DEBUG_BREAKPOINT_CODE;
		public static int DEBUG_BREAKPOINT_DATA = 1;
		public static int DEBUG_BREAKPOINT_TIME = 2;
		public static int DEBUG_BREAKPOINT_GO_ONLY = 1;
		public static int DEBUG_BREAKPOINT_DEFERRED = 2;
		public static int DEBUG_BREAKPOINT_ENABLED = 4;
		public static int DEBUG_BREAKPOINT_ADDER_ONLY = 8;
		public static int DEBUG_BREAKPOINT_ONE_SHOT = 0x10;
		public static int DEBUG_BREAK_READ = 1;
		public static int DEBUG_BREAK_WRITE = 2;
		public static int DEBUG_BREAK_EXECUTE = 4;
		public static int DEBUG_BREAK_IO = 8;
		public static int DEBUG_ATTACH_KERNEL_CONNECTION;
		public static int DEBUG_ATTACH_LOCAL_KERNEL = 1;
		public static int DEBUG_ATTACH_EXDI_DRIVER = 2;
		public static int DEBUG_GET_PROC_DEFAULT;
		public static int DEBUG_GET_PROC_FULL_MATCH = 1;
		public static int DEBUG_GET_PROC_ONLY_MATCH = 2;
		public static int DEBUG_GET_PROC_SERVICE_NAME = 4;
		public static int DEBUG_PROC_DESC_DEFAULT;
		public static int DEBUG_PROC_DESC_NO_PATHS = 1;
		public static int DEBUG_PROC_DESC_NO_SERVICES = 2;
		public static int DEBUG_PROC_DESC_NO_MTS_PACKAGES = 4;
		public static int DEBUG_PROC_DESC_NO_COMMAND_LINE = 8;
		public static int DEBUG_PROC_DESC_NO_SESSION_ID = 0x10;
		public static int DEBUG_PROC_DESC_NO_USER_NAME = 0x20;
		public static int DEBUG_ATTACH_DEFAULT;
		public static int DEBUG_ATTACH_NONINVASIVE = 1;
		public static int DEBUG_ATTACH_EXISTING = 2;
		public static int DEBUG_ATTACH_NONINVASIVE_NO_SUSPEND = 4;
		public static int DEBUG_ATTACH_INVASIVE_NO_INITIAL_BREAK = 8;
		public static int DEBUG_ATTACH_INVASIVE_RESUME_PROCESS = 0x10;
		public static int DEBUG_ATTACH_NONINVASIVE_ALLOW_PARTIAL = 0x20;
		public static int DEBUG_ECREATE_PROCESS_DEFAULT;
		public static int DEBUG_ECREATE_PROCESS_INHERIT_HANDLES = 1;
		public static int DEBUG_ECREATE_PROCESS_USE_VERIFIER_FLAGS = 2;
		public static int DEBUG_ECREATE_PROCESS_USE_IMPLICIT_COMMAND_LINE = 4;
		public static int DEBUG_PROCESS_DETACH_ON_EXIT = 1;
		public static int DEBUG_PROCESS_ONLY_THIS_PROCESS = 2;
		public static int DEBUG_CONNECT_SESSION_DEFAULT;
		public static int DEBUG_CONNECT_SESSION_NO_VERSION = 1;
		public static int DEBUG_CONNECT_SESSION_NO_ANNOUNCE = 2;
		public static int DEBUG_SERVERS_DEBUGGER = 1;
		public static int DEBUG_SERVERS_PROCESS = 2;
		public static int DEBUG_SERVERS_ALL = 3;
		public static int DEBUG_END_PASSIVE;
		public static int DEBUG_END_ACTIVE_TERMINATE = 1;
		public static int DEBUG_END_ACTIVE_DETACH = 2;
		public static int DEBUG_END_REENTRANT = 3;
		public static int DEBUG_END_DISCONNECT = 4;
		public static int DEBUG_OUTPUT_NORMAL = 1;
		public static int DEBUG_OUTPUT_ERROR = 2;
		public static int DEBUG_OUTPUT_WARNING = 4;
		public static int DEBUG_OUTPUT_VERBOSE = 8;
		public static int DEBUG_OUTPUT_PROMPT = 0x10;
		public static int DEBUG_OUTPUT_PROMPT_REGISTERS = 0x20;
		public static int DEBUG_OUTPUT_EXTENSION_WARNING = 0x40;
		public static int DEBUG_OUTPUT_DEBUGGEE = 0x80;
		public static int DEBUG_OUTPUT_DEBUGGEE_PROMPT = 0x100;
		public static int DEBUG_OUTPUT_SYMBOLS = 0x200;
		public static int DEBUG_IOUTPUT_KD_PROTOCOL = -2147483648;
		public static int DEBUG_IOUTPUT_REMOTING = 0x40000000;
		public static int DEBUG_IOUTPUT_BREAKPOINT = 0x20000000;
		public static int DEBUG_IOUTPUT_EVENT = 0x10000000;
		public static int DEBUG_OUTPUT_IDENTITY_DEFAULT;
		public static int DEBUG_FORMAT_DEFAULT;
		public static int DEBUG_FORMAT_WRITE_CAB = 0x20000000;
		public static int DEBUG_FORMAT_CAB_SECONDARY_FILES = 0x40000000;
		public static int DEBUG_FORMAT_NO_OVERWRITE = -2147483648;
		public static int DEBUG_FORMAT_USER_SMALL_FULL_MEMORY = 1;
		public static int DEBUG_FORMAT_USER_SMALL_HANDLE_DATA = 2;
		public static int DEBUG_FORMAT_USER_SMALL_UNLOADED_MODULES = 4;
		public static int DEBUG_FORMAT_USER_SMALL_INDIRECT_MEMORY = 8;
		public static int DEBUG_FORMAT_USER_SMALL_DATA_SEGMENTS = 0x10;
		public static int DEBUG_FORMAT_USER_SMALL_FILTER_MEMORY = 0x20;
		public static int DEBUG_FORMAT_USER_SMALL_FILTER_PATHS = 0x40;
		public static int DEBUG_FORMAT_USER_SMALL_PROCESS_THREAD_DATA = 0x80;
		public static int DEBUG_FORMAT_USER_SMALL_PRIVATE_READ_WRITE_MEMORY = 0x100;
		public static int DEBUG_FORMAT_USER_SMALL_NO_OPTIONAL_DATA = 0x200;
		public static int DEBUG_FORMAT_USER_SMALL_FULL_MEMORY_INFO = 0x400;
		public static int DEBUG_FORMAT_USER_SMALL_THREAD_INFO = 0x800;
		public static int DEBUG_FORMAT_USER_SMALL_CODE_SEGMENTS = 0x1000;
		public static int DEBUG_FORMAT_USER_SMALL_NO_AUXILIARY_STATE = 0x2000;
		public static int DEBUG_FORMAT_USER_SMALL_FULL_AUXILIARY_STATE = 0x4000;
		public static int DEBUG_DUMP_FILE_BASE = -1;
		public static int DEBUG_DUMP_FILE_PAGE_FILE_DUMP;
		public static int DEBUG_DUMP_FILE_LOAD_FAILED_INDEX = -1;
		public static int DEBUG_DUMP_FILE_ORIGINAL_CAB_INDEX = -2;
		public static int DEBUG_STATUS_NO_CHANGE;
		public static int DEBUG_STATUS_GO = 1;
		public static int DEBUG_STATUS_GO_HANDLED = 2;
		public static int DEBUG_STATUS_GO_NOT_HANDLED = 3;
		public static int DEBUG_STATUS_STEP_OVER = 4;
		public static int DEBUG_STATUS_STEP_INTO = 5;
		public static int DEBUG_STATUS_BREAK = 6;
		public static int DEBUG_STATUS_NO_DEBUGGEE = 7;
		public static int DEBUG_STATUS_STEP_BRANCH = 8;
		public static int DEBUG_STATUS_IGNORE_EVENT = 9;
		public static int DEBUG_STATUS_RESTART_REQUESTED = 10;
		public static int DEBUG_STATUS_REVERSE_GO = 11;
		public static int DEBUG_STATUS_REVERSE_STEP_BRANCH = 12;
		public static int DEBUG_STATUS_REVERSE_STEP_OVER = 13;
		public static int DEBUG_STATUS_REVERSE_STEP_INTO = 14;
		public static int DEBUG_STATUS_MASK = 15;
		public static int DEBUG_OUTCTL_THIS_CLIENT;
		public static int DEBUG_OUTCTL_ALL_CLIENTS = 1;
		public static int DEBUG_OUTCTL_ALL_OTHER_CLIENTS = 2;
		public static int DEBUG_OUTCTL_IGNORE = 3;
		public static int DEBUG_OUTCTL_LOG_ONLY = 4;
		public static int DEBUG_OUTCTL_SEND_MASK = 7;
		public static int DEBUG_OUTCTL_NOT_LOGGED = 8;
		public static int DEBUG_OUTCTL_OVERRIDE_MASK = 0x10;
		public static int DEBUG_OUTCTL_DML = 0x20;
		public static int DEBUG_OUTCTL_AMBIENT_DML = -2;
		public static int DEBUG_OUTCTL_AMBIENT_TEXT = -1;
		public static int DEBUG_INTERRUPT_ACTIVE;
		public static int DEBUG_INTERRUPT_PASSIVE = 1;
		public static int DEBUG_INTERRUPT_EXIT = 2;
		public static int DEBUG_CURRENT_DEFAULT = 15;
		public static int DEBUG_CURRENT_SYMBOL = 1;
		public static int DEBUG_CURRENT_DISASM = 2;
		public static int DEBUG_CURRENT_REGISTERS = 4;
		public static int DEBUG_CURRENT_SOURCE_LINE = 8;
		public static int DEBUG_DISASM_EFFECTIVE_ADDRESS = 1;
		public static int DEBUG_DISASM_MATCHING_SYMBOLS = 2;
		public static int DEBUG_DISASM_SOURCE_LINE_NUMBER = 4;
		public static int DEBUG_DISASM_SOURCE_FILE_NAME = 8;
		public static int DEBUG_LEVEL_SOURCE;
		public static int DEBUG_LEVEL_ASSEMBLY = 1;
		public static int DEBUG_ENGOPT_IGNORE_DBGHELP_VERSION = 1;
		public static int DEBUG_ENGOPT_IGNORE_EXTENSION_VERSIONS = 2;
		public static int DEBUG_ENGOPT_ALLOW_NETWORK_PATHS = 4;
		public static int DEBUG_ENGOPT_DISALLOW_NETWORK_PATHS = 8;
		public static int DEBUG_ENGOPT_IGNORE_LOADER_EXCEPTIONS = 0x10;
		public static int DEBUG_ENGOPT_INITIAL_BREAK = 0x20;
		public static int DEBUG_ENGOPT_INITIAL_MODULE_BREAK = 0x40;
		public static int DEBUG_ENGOPT_FINAL_BREAK = 0x80;
		public static int DEBUG_ENGOPT_NO_EXECUTE_REPEAT = 0x100;
		public static int DEBUG_ENGOPT_FAIL_INCOMPLETE_INFORMATION = 0x200;
		public static int DEBUG_ENGOPT_ALLOW_READ_ONLY_BREAKPOINTS = 0x400;
		public static int DEBUG_ENGOPT_SYNCHRONIZE_BREAKPOINTS = 0x800;
		public static int DEBUG_ENGOPT_DISALLOW_SHELL_COMMANDS = 0x1000;
		public static int DEBUG_ENGOPT_KD_QUIET_MODE = 0x2000;
		public static int DEBUG_ENGOPT_DISABLE_MANAGED_SUPPORT = 0x4000;
		public static int DEBUG_ENGOPT_DISABLE_MODULE_SYMBOL_LOAD = 0x8000;
		public static int DEBUG_ENGOPT_DISABLE_EXECUTION_COMMANDS = 0x10000;
		public static int DEBUG_ENGOPT_DISALLOW_IMAGE_FILE_MAPPING = 0x20000;
		public static int DEBUG_ENGOPT_PREFER_DML = 0x40000;
		public static int DEBUG_ENGOPT_ALL = 0x7ffff;
		public static int DEBUG_ANY_ID = -1;
		public static int DEBUG_STACK_ARGUMENTS = 1;
		public static int DEBUG_STACK_FUNCTION_INFO = 2;
		public static int DEBUG_STACK_SOURCE_LINE = 4;
		public static int DEBUG_STACK_FRAME_ADDRESSES = 8;
		public static int DEBUG_STACK_COLUMN_NAMES = 0x10;
		public static int DEBUG_STACK_NONVOLATILE_REGISTERS = 0x20;
		public static int DEBUG_STACK_FRAME_NUMBERS = 0x40;
		public static int DEBUG_STACK_PARAMETERS = 0x80;
		public static int DEBUG_STACK_FRAME_ADDRESSES_RA_ONLY = 0x100;
		public static int DEBUG_STACK_FRAME_MEMORY_USAGE = 0x200;
		public static int DEBUG_STACK_PARAMETERS_NEWLINE = 0x400;
		public static int DEBUG_STACK_DML = 0x800;
		public static int DEBUG_CLASS_UNINITIALIZED;
		public static int DEBUG_CLASS_KERNEL = 1;
		public static int DEBUG_CLASS_USER_WINDOWS = 2;
		public static int DEBUG_CLASS_IMAGE_FILE = 3;
		public static int DEBUG_DUMP_SMALL = 0x400;
		public static int DEBUG_DUMP_DEFAULT = 0x401;
		public static int DEBUG_DUMP_FULL = 0x402;
		public static int DEBUG_DUMP_IMAGE_FILE = 0x403;
		public static int DEBUG_DUMP_TRACE_LOG = 0x404;
		public static int DEBUG_DUMP_WINDOWS_CE = 0x405;
		public static int DEBUG_KERNEL_CONNECTION;
		public static int DEBUG_KERNEL_LOCAL = 1;
		public static int DEBUG_KERNEL_EXDI_DRIVER = 2;
		public static int DEBUG_USER_WINDOWS_PROCESS;
		public static int DEBUG_USER_WINDOWS_PROCESS_SERVER = 1;
		public static int DEBUG_USER_WINDOWS_IDNA = 2;
		public static int DEBUG_EXTENSION_AT_ENGINE;
		public static int DEBUG_EXECUTE_DEFAULT;
		public static int DEBUG_EXECUTE_ECHO = 1;
		public static int DEBUG_EXECUTE_NOT_LOGGED = 2;
		public static int DEBUG_EXECUTE_NO_REPEAT = 4;
		public static int DEBUG_FILTER_CREATE_THREAD;
		public static int DEBUG_FILTER_EXIT_THREAD = 1;
		public static int DEBUG_FILTER_CREATE_PROCESS = 2;
		public static int DEBUG_FILTER_EXIT_PROCESS = 3;
		public static int DEBUG_FILTER_LOAD_MODULE = 4;
		public static int DEBUG_FILTER_UNLOAD_MODULE = 5;
		public static int DEBUG_FILTER_SYSTEM_ERROR = 6;
		public static int DEBUG_FILTER_INITIAL_BREAKPOINT = 7;
		public static int DEBUG_FILTER_INITIAL_MODULE_LOAD = 8;
		public static int DEBUG_FILTER_DEBUGGEE_OUTPUT = 9;
		public static int DEBUG_FILTER_BREAK;
		public static int DEBUG_FILTER_SECOND_CHANCE_BREAK = 1;
		public static int DEBUG_FILTER_OUTPUT = 2;
		public static int DEBUG_FILTER_IGNORE = 3;
		public static int DEBUG_FILTER_REMOVE = 4;
		public static int DEBUG_FILTER_GO_HANDLED;
		public static int DEBUG_FILTER_GO_NOT_HANDLED = 1;
		public static int DEBUG_WAIT_DEFAULT;
		public static int DEBUG_VALUE_INVALID;
		public static int DEBUG_VALUE_INT8 = 1;
		public static int DEBUG_VALUE_INT16 = 2;
		public static int DEBUG_VALUE_INT32 = 3;
		public static int DEBUG_VALUE_INT64 = 4;
		public static int DEBUG_VALUE_FLOAT32 = 5;
		public static int DEBUG_VALUE_FLOAT64 = 6;
		public static int DEBUG_VALUE_FLOAT80 = 7;
		public static int DEBUG_VALUE_FLOAT82 = 8;
		public static int DEBUG_VALUE_FLOAT128 = 9;
		public static int DEBUG_VALUE_VECTOR64 = 10;
		public static int DEBUG_VALUE_VECTOR128 = 11;
		public static int DEBUG_VALUE_TYPES = 12;
		public static int DEBUG_OUT_TEXT_REPL_DEFAULT;
		public static int DEBUG_ASMOPT_DEFAULT;
		public static int DEBUG_ASMOPT_VERBOSE = 1;
		public static int DEBUG_ASMOPT_NO_CODE_BYTES = 2;
		public static int DEBUG_ASMOPT_IGNORE_OUTPUT_WIDTH = 4;
		public static int DEBUG_ASMOPT_SOURCE_LINE_NUMBER = 8;
		public static int DEBUG_EXPR_MASM;
		public static int DEBUG_EXPR_CPLUSPLUS = 1;
		public static int DEBUG_EINDEX_NAME;
		public static int DEBUG_EINDEX_FROM_START;
		public static int DEBUG_EINDEX_FROM_END = 1;
		public static int DEBUG_EINDEX_FROM_CURRENT = 2;
		public static int DEBUG_LOG_DEFAULT;
		public static int DEBUG_LOG_APPEND = 1;
		public static int DEBUG_LOG_UNICODE = 2;
		public static int DEBUG_LOG_DML = 4;
		public static int DEBUG_SYSVERSTR_SERVICE_PACK;
		public static int DEBUG_SYSVERSTR_BUILD = 1;
		public static int DEBUG_MANAGED_DISABLED;
		public static int DEBUG_MANAGED_ALLOWED = 1;
		public static int DEBUG_MANAGED_DLL_LOADED = 2;
		public static int DEBUG_MANSTR_NONE;
		public static int DEBUG_MANSTR_LOADED_SUPPORT_DLL = 1;
		public static int DEBUG_MANSTR_LOAD_STATUS = 2;
		public static int DEBUG_MANRESET_DEFAULT;
		public static int DEBUG_MANRESET_LOAD_DLL = 1;
		public static int DEBUG_DATA_SPACE_VIRTUAL;
		public static int DEBUG_DATA_SPACE_PHYSICAL = 1;
		public static int DEBUG_DATA_SPACE_CONTROL = 2;
		public static int DEBUG_DATA_SPACE_IO = 3;
		public static int DEBUG_DATA_SPACE_MSR = 4;
		public static int DEBUG_DATA_SPACE_BUS_DATA = 5;
		public static int DEBUG_DATA_SPACE_DEBUGGER_DATA = 6;
		public static int DEBUG_DATA_SPACE_COUNT = 7;
		public static int DEBUG_DATA_KernBase = 0x18;
		public static int DEBUG_DATA_BreakpointWithStatusAddr = 0x20;
		public static int DEBUG_DATA_SavedContextAddr = 40;
		public static int DEBUG_DATA_KiCallUserModeAddr = 0x38;
		public static int DEBUG_DATA_KeUserCallbackDispatcherAddr = 0x40;
		public static int DEBUG_DATA_PsLoadedModuleListAddr = 0x48;
		public static int DEBUG_DATA_PsActiveProcessHeadAddr = 80;
		public static int DEBUG_DATA_PspCidTableAddr = 0x58;
		public static int DEBUG_DATA_ExpSystemResourcesListAddr = 0x60;
		public static int DEBUG_DATA_ExpPagedPoolDescriptorAddr = 0x68;
		public static int DEBUG_DATA_ExpNumberOfPagedPoolsAddr = 0x70;
		public static int DEBUG_DATA_KeTimeIncrementAddr = 120;
		public static int DEBUG_DATA_KeBugCheckCallbackListHeadAddr = 0x80;
		public static int DEBUG_DATA_KiBugcheckDataAddr = 0x88;
		public static int DEBUG_DATA_IopErrorLogListHeadAddr = 0x90;
		public static int DEBUG_DATA_ObpRootDirectoryObjectAddr = 0x98;
		public static int DEBUG_DATA_ObpTypeObjectTypeAddr = 160;
		public static int DEBUG_DATA_MmSystemCacheStartAddr = 0xa8;
		public static int DEBUG_DATA_MmSystemCacheEndAddr = 0xb0;
		public static int DEBUG_DATA_MmSystemCacheWsAddr = 0xb8;
		public static int DEBUG_DATA_MmPfnDatabaseAddr = 0xc0;
		public static int DEBUG_DATA_MmSystemPtesStartAddr = 200;
		public static int DEBUG_DATA_MmSystemPtesEndAddr = 0xd0;
		public static int DEBUG_DATA_MmSubsectionBaseAddr = 0xd8;
		public static int DEBUG_DATA_MmNumberOfPagingFilesAddr = 0xe0;
		public static int DEBUG_DATA_MmLowestPhysicalPageAddr = 0xe8;
		public static int DEBUG_DATA_MmHighestPhysicalPageAddr = 240;
		public static int DEBUG_DATA_MmNumberOfPhysicalPagesAddr = 0xf8;
		public static int DEBUG_DATA_MmMaximumNonPagedPoolInBytesAddr = 0x100;
		public static int DEBUG_DATA_MmNonPagedSystemStartAddr = 0x108;
		public static int DEBUG_DATA_MmNonPagedPoolStartAddr = 0x110;
		public static int DEBUG_DATA_MmNonPagedPoolEndAddr = 280;
		public static int DEBUG_DATA_MmPagedPoolStartAddr = 0x120;
		public static int DEBUG_DATA_MmPagedPoolEndAddr = 0x128;
		public static int DEBUG_DATA_MmPagedPoolInformationAddr = 0x130;
		public static int DEBUG_DATA_MmPageSize = 0x138;
		public static int DEBUG_DATA_MmSizeOfPagedPoolInBytesAddr = 320;
		public static int DEBUG_DATA_MmTotalCommitLimitAddr = 0x148;
		public static int DEBUG_DATA_MmTotalCommittedPagesAddr = 0x150;
		public static int DEBUG_DATA_MmSharedCommitAddr = 0x158;
		public static int DEBUG_DATA_MmDriverCommitAddr = 0x160;
		public static int DEBUG_DATA_MmProcessCommitAddr = 360;
		public static int DEBUG_DATA_MmPagedPoolCommitAddr = 0x170;
		public static int DEBUG_DATA_MmExtendedCommitAddr = 0x178;
		public static int DEBUG_DATA_MmZeroedPageListHeadAddr = 0x180;
		public static int DEBUG_DATA_MmFreePageListHeadAddr = 0x188;
		public static int DEBUG_DATA_MmStandbyPageListHeadAddr = 400;
		public static int DEBUG_DATA_MmModifiedPageListHeadAddr = 0x198;
		public static int DEBUG_DATA_MmModifiedNoWritePageListHeadAddr = 0x1a0;
		public static int DEBUG_DATA_MmAvailablePagesAddr = 0x1a8;
		public static int DEBUG_DATA_MmResidentAvailablePagesAddr = 0x1b0;
		public static int DEBUG_DATA_PoolTrackTableAddr = 440;
		public static int DEBUG_DATA_NonPagedPoolDescriptorAddr = 0x1c0;
		public static int DEBUG_DATA_MmHighestUserAddressAddr = 0x1c8;
		public static int DEBUG_DATA_MmSystemRangeStartAddr = 0x1d0;
		public static int DEBUG_DATA_MmUserProbeAddressAddr = 0x1d8;
		public static int DEBUG_DATA_KdPrintCircularBufferAddr = 480;
		public static int DEBUG_DATA_KdPrintCircularBufferEndAddr = 0x1e8;
		public static int DEBUG_DATA_KdPrintWritePointerAddr = 0x1f0;
		public static int DEBUG_DATA_KdPrintRolloverCountAddr = 0x1f8;
		public static int DEBUG_DATA_MmLoadedUserImageListAddr = 0x200;
		public static int DEBUG_DATA_NtBuildLabAddr = 520;
		public static int DEBUG_DATA_KiNormalSystemCall = 0x210;
		public static int DEBUG_DATA_KiProcessorBlockAddr = 0x218;
		public static int DEBUG_DATA_MmUnloadedDriversAddr = 0x220;
		public static int DEBUG_DATA_MmLastUnloadedDriverAddr = 0x228;
		public static int DEBUG_DATA_MmTriageActionTakenAddr = 560;
		public static int DEBUG_DATA_MmSpecialPoolTagAddr = 0x238;
		public static int DEBUG_DATA_KernelVerifierAddr = 0x240;
		public static int DEBUG_DATA_MmVerifierDataAddr = 0x248;
		public static int DEBUG_DATA_MmAllocatedNonPagedPoolAddr = 0x250;
		public static int DEBUG_DATA_MmPeakCommitmentAddr = 600;
		public static int DEBUG_DATA_MmTotalCommitLimitMaximumAddr = 0x260;
		public static int DEBUG_DATA_CmNtCSDVersionAddr = 0x268;
		public static int DEBUG_DATA_MmPhysicalMemoryBlockAddr = 0x270;
		public static int DEBUG_DATA_MmSessionBase = 0x278;
		public static int DEBUG_DATA_MmSessionSize = 640;
		public static int DEBUG_DATA_MmSystemParentTablePage = 0x288;
		public static int DEBUG_DATA_MmVirtualTranslationBase = 0x290;
		public static int DEBUG_DATA_OffsetKThreadNextProcessor = 0x298;
		public static int DEBUG_DATA_OffsetKThreadTeb = 0x29a;
		public static int DEBUG_DATA_OffsetKThreadKernelStack = 0x29c;
		public static int DEBUG_DATA_OffsetKThreadInitialStack = 670;
		public static int DEBUG_DATA_OffsetKThreadApcProcess = 0x2a0;
		public static int DEBUG_DATA_OffsetKThreadState = 0x2a2;
		public static int DEBUG_DATA_OffsetKThreadBStore = 0x2a4;
		public static int DEBUG_DATA_OffsetKThreadBStoreLimit = 0x2a6;
		public static int DEBUG_DATA_SizeEProcess = 680;
		public static int DEBUG_DATA_OffsetEprocessPeb = 0x2aa;
		public static int DEBUG_DATA_OffsetEprocessParentCID = 0x2ac;
		public static int DEBUG_DATA_OffsetEprocessDirectoryTableBase = 0x2ae;
		public static int DEBUG_DATA_SizePrcb = 0x2b0;
		public static int DEBUG_DATA_OffsetPrcbDpcRoutine = 690;
		public static int DEBUG_DATA_OffsetPrcbCurrentThread = 0x2b4;
		public static int DEBUG_DATA_OffsetPrcbMhz = 0x2b6;
		public static int DEBUG_DATA_OffsetPrcbCpuType = 0x2b8;
		public static int DEBUG_DATA_OffsetPrcbVendorString = 0x2ba;
		public static int DEBUG_DATA_OffsetPrcbProcessorState = 700;
		public static int DEBUG_DATA_OffsetPrcbNumber = 0x2be;
		public static int DEBUG_DATA_SizeEThread = 0x2c0;
		public static int DEBUG_DATA_KdPrintCircularBufferPtrAddr = 0x2c8;
		public static int DEBUG_DATA_KdPrintBufferSizeAddr = 720;
		public static int DEBUG_DATA_PaeEnabled = 0x186a0;
		public static int DEBUG_DATA_SharedUserData = 0x186a8;
		public static int DEBUG_DATA_ProductType = 0x186b0;
		public static int DEBUG_DATA_SuiteMask = 0x186b8;
		public static int DEBUG_DATA_DumpWriterStatus = 0x186c0;
		public static int DEBUG_DATA_DumpFormatVersion = 0x186c8;
		public static int DEBUG_DATA_DumpWriterVersion = 0x186d0;
		public static int DEBUG_DATA_DumpPowerState = 0x186d8;
		public static int DEBUG_DATA_DumpMmStorage = 0x186e0;
		public static int DEBUG_DATA_KPCR_OFFSET;
		public static int DEBUG_DATA_KPRCB_OFFSET = 1;
		public static int DEBUG_DATA_KTHREAD_OFFSET = 2;
		public static int DEBUG_DATA_BASE_TRANSLATION_VIRTUAL_OFFSET = 3;
		public static int DEBUG_DATA_PROCESSOR_IDENTIFICATION = 4;
		public static int DEBUG_DATA_PROCESSOR_SPEED = 5;
		public static int DEBUG_HANDLE_DATA_TYPE_BASIC;
		public static int DEBUG_HANDLE_DATA_TYPE_TYPE_NAME = 1;
		public static int DEBUG_HANDLE_DATA_TYPE_OBJECT_NAME = 2;
		public static int DEBUG_HANDLE_DATA_TYPE_HANDLE_COUNT = 3;
		public static int DEBUG_HANDLE_DATA_TYPE_TYPE_NAME_WIDE = 4;
		public static int DEBUG_HANDLE_DATA_TYPE_OBJECT_NAME_WIDE = 5;
		public static int DEBUG_HANDLE_DATA_TYPE_MINI_THREAD_1 = 6;
		public static int DEBUG_HANDLE_DATA_TYPE_MINI_MUTANT_1 = 7;
		public static int DEBUG_HANDLE_DATA_TYPE_MINI_MUTANT_2 = 8;
		public static int DEBUG_HANDLE_DATA_TYPE_PER_HANDLE_OPERATIONS = 9;
		public static int DEBUG_HANDLE_DATA_TYPE_ALL_HANDLE_OPERATIONS = 10;
		public static int DEBUG_HANDLE_DATA_TYPE_MINI_PROCESS_1 = 11;
		public static int DEBUG_HANDLE_DATA_TYPE_MINI_PROCESS_2 = 12;
		public static int DEBUG_OFFSINFO_VIRTUAL_SOURCE = 1;
		public static int DEBUG_VSOURCE_INVALID;
		public static int DEBUG_VSOURCE_DEBUGGEE = 1;
		public static int DEBUG_VSOURCE_MAPPED_IMAGE = 2;
		public static int DEBUG_VSEARCH_DEFAULT;
		public static int DEBUG_VSEARCH_WRITABLE_ONLY = 1;
		public static int DEBUG_PHYSICAL_DEFAULT;
		public static int DEBUG_PHYSICAL_CACHED = 1;
		public static int DEBUG_PHYSICAL_UNCACHED = 2;
		public static int DEBUG_PHYSICAL_WRITE_COMBINED = 3;
		public static int DEBUG_EVENT_BREAKPOINT = 1;
		public static int DEBUG_EVENT_EXCEPTION = 2;
		public static int DEBUG_EVENT_CREATE_THREAD = 4;
		public static int DEBUG_EVENT_EXIT_THREAD = 8;
		public static int DEBUG_EVENT_CREATE_PROCESS = 0x10;
		public static int DEBUG_EVENT_EXIT_PROCESS = 0x20;
		public static int DEBUG_EVENT_LOAD_MODULE = 0x40;
		public static int DEBUG_EVENT_UNLOAD_MODULE = 0x80;
		public static int DEBUG_EVENT_SYSTEM_ERROR = 0x100;
		public static int DEBUG_EVENT_SESSION_STATUS = 0x200;
		public static int DEBUG_EVENT_CHANGE_DEBUGGEE_STATE = 0x400;
		public static int DEBUG_EVENT_CHANGE_ENGINE_STATE = 0x800;
		public static int DEBUG_EVENT_CHANGE_SYMBOL_STATE = 0x1000;
		public static int DEBUG_SESSION_ACTIVE;
		public static int DEBUG_SESSION_END_SESSION_ACTIVE_TERMINATE = 1;
		public static int DEBUG_SESSION_END_SESSION_ACTIVE_DETACH = 2;
		public static int DEBUG_SESSION_END_SESSION_PASSIVE = 3;
		public static int DEBUG_SESSION_END = 4;
		public static int DEBUG_SESSION_REBOOT = 5;
		public static int DEBUG_SESSION_HIBERNATE = 6;
		public static int DEBUG_SESSION_FAILURE = 7;
		public static int DEBUG_CDS_ALL = -1;
		public static int DEBUG_CDS_REGISTERS = 1;
		public static int DEBUG_CDS_DATA = 2;
		public static int DEBUG_CES_ALL = -1;
		public static int DEBUG_CES_CURRENT_THREAD = 1;
		public static int DEBUG_CES_EFFECTIVE_PROCESSOR = 2;
		public static int DEBUG_CES_BREAKPOINTS = 4;
		public static int DEBUG_CES_CODE_LEVEL = 8;
		public static int DEBUG_CES_EXECUTION_STATUS = 0x10;
		public static int DEBUG_CES_ENGINE_OPTIONS = 0x20;
		public static int DEBUG_CES_LOG_FILE = 0x40;
		public static int DEBUG_CES_RADIX = 0x80;
		public static int DEBUG_CES_EVENT_FILTERS = 0x100;
		public static int DEBUG_CES_PROCESS_OPTIONS = 0x200;
		public static int DEBUG_CES_EXTENSIONS = 0x400;
		public static int DEBUG_CES_SYSTEMS = 0x800;
		public static int DEBUG_CES_ASSEMBLY_OPTIONS = 0x1000;
		public static int DEBUG_CES_EXPRESSION_SYNTAX = 0x2000;
		public static int DEBUG_CES_TEXT_REPLACEMENTS = 0x4000;
		public static int DEBUG_CSS_ALL = -1;
		public static int DEBUG_CSS_LOADS = 1;
		public static int DEBUG_CSS_UNLOADS = 2;
		public static int DEBUG_CSS_SCOPE = 4;
		public static int DEBUG_CSS_PATHS = 8;
		public static int DEBUG_CSS_SYMBOL_OPTIONS = 0x10;
		public static int DEBUG_CSS_TYPE_OPTIONS = 0x20;
		public static int DEBUG_OUTCBI_EXPLICIT_FLUSH = 1;
		public static int DEBUG_OUTCBI_TEXT = 2;
		public static int DEBUG_OUTCBI_DML = 4;
		public static int DEBUG_OUTCBI_ANY_FORMAT = 6;
		public static int DEBUG_OUTCB_TEXT;
		public static int DEBUG_OUTCB_DML = 1;
		public static int DEBUG_OUTCB_EXPLICIT_FLUSH = 2;
		public static int DEBUG_OUTCBF_COMBINED_EXPLICIT_FLUSH = 1;
		public static int DEBUG_OUTCBF_DML_HAS_TAGS = 2;
		public static int DEBUG_OUTCBF_DML_HAS_SPECIAL_CHARACTERS = 4;
		public static int DEBUG_REGISTERS_DEFAULT;
		public static int DEBUG_REGISTERS_INT32 = 1;
		public static int DEBUG_REGISTERS_INT64 = 2;
		public static int DEBUG_REGISTERS_FLOAT = 4;
		public static int DEBUG_REGISTERS_ALL = 7;
		public static int DEBUG_REGISTER_SUB_REGISTER = 1;
		public static int DEBUG_REGSRC_DEBUGGEE;
		public static int DEBUG_REGSRC_EXPLICIT = 1;
		public static int DEBUG_REGSRC_FRAME = 2;
		public static int DEBUG_OUTPUT_SYMBOLS_DEFAULT;
		public static int DEBUG_OUTPUT_SYMBOLS_NO_NAMES = 1;
		public static int DEBUG_OUTPUT_SYMBOLS_NO_OFFSETS = 2;
		public static int DEBUG_OUTPUT_SYMBOLS_NO_VALUES = 4;
		public static int DEBUG_OUTPUT_SYMBOLS_NO_TYPES = 0x10;
		public static int DEBUG_SYMBOL_EXPANSION_LEVEL_MASK = 15;
		public static int DEBUG_SYMBOL_EXPANDED = 0x10;
		public static int DEBUG_SYMBOL_READ_ONLY = 0x20;
		public static int DEBUG_SYMBOL_IS_ARRAY = 0x40;
		public static int DEBUG_SYMBOL_IS_FLOAT = 0x80;
		public static int DEBUG_SYMBOL_IS_ARGUMENT = 0x100;
		public static int DEBUG_SYMBOL_IS_LOCAL = 0x200;
		public static int DEBUG_SYMENT_IS_CODE = 1;
		public static int DEBUG_SYMENT_IS_DATA = 2;
		public static int DEBUG_SYMENT_IS_PARAMETER = 4;
		public static int DEBUG_SYMENT_IS_LOCAL = 8;
		public static int DEBUG_SYMENT_IS_MANAGED = 0x10;
		public static int DEBUG_SYMENT_IS_SYNTHETIC = 0x20;
		public static int DEBUG_MODULE_LOADED;
		public static int DEBUG_MODULE_UNLOADED = 1;
		public static int DEBUG_MODULE_USER_MODE = 2;
		public static int DEBUG_MODULE_EXPLICIT = 8;
		public static int DEBUG_MODULE_SECONDARY = 0x10;
		public static int DEBUG_MODULE_SYNTHETIC = 0x20;
		public static int DEBUG_MODULE_SYM_BAD_CHECKSUM = 0x10000;
		public static int DEBUG_SYMTYPE_NONE;
		public static int DEBUG_SYMTYPE_COFF = 1;
		public static int DEBUG_SYMTYPE_CODEVIEW = 2;
		public static int DEBUG_SYMTYPE_PDB = 3;
		public static int DEBUG_SYMTYPE_EXPORT = 4;
		public static int DEBUG_SYMTYPE_DEFERRED = 5;
		public static int DEBUG_SYMTYPE_SYM = 6;
		public static int DEBUG_SYMTYPE_DIA = 7;
		public static int DEBUG_SCOPE_GROUP_ARGUMENTS = 1;
		public static int DEBUG_SCOPE_GROUP_LOCALS = 2;
		public static int DEBUG_SCOPE_GROUP_ALL = 3;
		public static int DEBUG_OUTTYPE_DEFAULT;
		public static int DEBUG_OUTTYPE_NO_INDENT = 1;
		public static int DEBUG_OUTTYPE_NO_OFFSET = 2;
		public static int DEBUG_OUTTYPE_VERBOSE = 4;
		public static int DEBUG_OUTTYPE_COMPACT_OUTPUT = 8;
		public static int DEBUG_OUTTYPE_ADDRESS_OF_FIELD = 0x10000;
		public static int DEBUG_OUTTYPE_ADDRESS_AT_END = 0x20000;
		public static int DEBUG_OUTTYPE_BLOCK_RECURSE = 0x200000;
		public static int DEBUG_FIND_SOURCE_DEFAULT;
		public static int DEBUG_FIND_SOURCE_FULL_PATH = 1;
		public static int DEBUG_FIND_SOURCE_BEST_MATCH = 2;
		public static int DEBUG_FIND_SOURCE_NO_SRCSRV = 4;
		public static int DEBUG_FIND_SOURCE_TOKEN_LOOKUP = 8;
		public static int DEBUG_MODNAME_IMAGE;
		public static int DEBUG_MODNAME_MODULE = 1;
		public static int DEBUG_MODNAME_LOADED_IMAGE = 2;
		public static int DEBUG_MODNAME_SYMBOL_FILE = 3;
		public static int DEBUG_MODNAME_MAPPED_IMAGE = 4;
		public static int DEBUG_TYPEOPTS_UNICODE_DISPLAY = 1;
		public static int DEBUG_TYPEOPTS_LONGSTATUS_DISPLAY = 2;
		public static int DEBUG_TYPEOPTS_FORCERADIX_OUTPUT = 4;
		public static int DEBUG_TYPEOPTS_MATCH_MAXSIZE = 8;
		public static int DEBUG_GETMOD_DEFAULT;
		public static int DEBUG_GETMOD_NO_LOADED_MODULES = 1;
		public static int DEBUG_GETMOD_NO_UNLOADED_MODULES = 2;
		public static int DEBUG_ADDSYNTHMOD_DEFAULT;
		public static int DEBUG_ADDSYNTHSYM_DEFAULT;
		public static int DEBUG_OUTSYM_DEFAULT;
		public static int DEBUG_OUTSYM_FORCE_OFFSET = 1;
		public static int DEBUG_OUTSYM_SOURCE_LINE = 2;
		public static int DEBUG_OUTSYM_ALLOW_DISPLACEMENT = 4;
		public static int DEBUG_GETFNENT_DEFAULT;
		public static int DEBUG_GETFNENT_RAW_ENTRY_ONLY = 1;
		public static int DEBUG_SOURCE_IS_STATEMENT = 1;
		public static int DEBUG_GSEL_DEFAULT;
		public static int DEBUG_GSEL_NO_SYMBOL_LOADS = 1;
		public static int DEBUG_GSEL_ALLOW_LOWER = 2;
		public static int DEBUG_GSEL_ALLOW_HIGHER = 4;
		public static int DEBUG_GSEL_NEAREST_ONLY = 8;
		public static int DEBUG_COMMAND_EXCEPTION_ID = -606073410;
		public static int DEBUG_CMDEX_INVALID;
		public static int DEBUG_CMDEX_ADD_EVENT_STRING = 1;
		public static int DEBUG_CMDEX_RESET_EVENT_STRINGS = 2;
		public static int DEBUG_EXTINIT_HAS_COMMAND_HELP = 1;
		public static int DEBUG_NOTIFY_SESSION_ACTIVE;
		public static int DEBUG_NOTIFY_SESSION_INACTIVE = 1;
		public static int DEBUG_NOTIFY_SESSION_ACCESSIBLE = 2;
		public static int DEBUG_NOTIFY_SESSION_INACCESSIBLE = 3;
		public static int DEBUG_KNOWN_STRUCT_GET_NAMES = 1;
		public static int DEBUG_KNOWN_STRUCT_GET_SINGLE_LINE_OUTPUT = 2;
		public static int DEBUG_KNOWN_STRUCT_SUPPRESS_TYPE_NAME = 3;
		public static int DEBUG_EXT_QVALUE_DEFAULT;
		public static int DEBUG_EXT_PVALUE_DEFAULT;
		public static int DEBUG_EXT_PVTYPE_IS_VALUE;
		public static int DEBUG_EXT_PVTYPE_IS_POINTER = 1;
	}
}
// end
