/*BEGIN_LEGAL 
Intel Open Source License 

Copyright (c) 2002-2011 Intel Corporation. All rights reserved.
 
Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are
met:

Redistributions of source code must retain the above copyright notice,
this list of conditions and the following disclaimer.  Redistributions
in binary form must reproduce the above copyright notice, this list of
conditions and the following disclaimer in the documentation and/or
other materials provided with the distribution.  Neither the name of
the Intel Corporation nor the names of its contributors may be used to
endorse or promote products derived from this software without
specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE INTEL OR
ITS CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
END_LEGAL */
/*
 * This tool is meant to run on the application "pc-change-async.cpp".
 */
 
#include <iostream>
#include <cstdlib>
#include "pin.H"

BOOL FoundBreakpointFunction = FALSE;
BOOL FoundBreakpointLocation = FALSE;
BOOL FoundOneFunction = FALSE;
BOOL FoundTwoFunction = FALSE;
BOOL FoundOneRtn = FALSE;
BOOL AllowBreakpoint = FALSE;

ADDRINT BreakpointFunction;
ADDRINT BreakpointLocation;
ADDRINT OneFunction;
ADDRINT TwoFunction;

PIN_LOCK Lock;


static VOID OnImage(IMG, VOID *);
static VOID InstrumentRtn(RTN rtn, VOID *);
static VOID AtOne();
static BOOL Intercept(THREADID, DEBUGGING_EVENT, CONTEXT *, VOID *);
static VOID OnExit(INT32, VOID *);


int main(int argc, char * argv[])
{
    PIN_Init(argc, argv);
    PIN_InitSymbols();
    InitLock(&Lock);

    IMG_AddInstrumentFunction(OnImage, 0);
    RTN_AddInstrumentFunction(InstrumentRtn, 0);
    PIN_InterceptDebuggingEvent(DEBUGGING_EVENT_BREAKPOINT, Intercept, 0);
    PIN_InterceptDebuggingEvent(DEBUGGING_EVENT_ASYNC_BREAK, Intercept, 0);
    PIN_AddFiniFunction(OnExit, 0);
    PIN_StartProgram();
    return 0;
}


static VOID OnImage(IMG img, VOID *)
{
    for (SYM sym = IMG_RegsymHead(img);  SYM_Valid(sym);  sym = SYM_Next(sym))
    {
        if (SYM_Name(sym) == "Breakpoint")
        {
            FoundBreakpointFunction = TRUE;
            BreakpointFunction = SYM_Address(sym);
        }
        if (SYM_Name(sym) == "BreakpointLocation")
        {
            FoundBreakpointLocation = TRUE;
            BreakpointLocation = SYM_Address(sym);
        }
        if (SYM_Name(sym) == "One")
        {
            FoundOneFunction = TRUE;
            OneFunction = SYM_Address(sym);
        }
        if (SYM_Name(sym) == "Two")
        {
            FoundTwoFunction = TRUE;
            TwoFunction = SYM_Address(sym);
        }
    }
}

static VOID InstrumentRtn(RTN rtn, VOID *)
{
    if (RTN_Name(rtn) == "One")
    {
        RTN_Open(rtn);
        RTN_InsertCall(rtn, IPOINT_BEFORE, AFUNPTR(AtOne), IARG_END);
        FoundOneRtn = TRUE;
        RTN_Close(rtn);
    }
}


static VOID AtOne()
{
    if (!AllowBreakpoint)
    {
        GetLock(&Lock, 1);
        std::cout << "Breakpoint is allowed" << std::endl;
        ReleaseLock(&Lock);
    }

    // When the main thread reaches the One() function, allow the child thread to trigger
    // the breakpoint.  The main thread will continue executing this instruction in a loop
    // until we intercept the DEBUGGING_EVENT_ASYNC_BREAK event below.
    //
    AllowBreakpoint = TRUE;
}


static BOOL Intercept(THREADID tid, DEBUGGING_EVENT eventType, CONTEXT *ctxt, VOID *)
{
    if (eventType == DEBUGGING_EVENT_BREAKPOINT)
    {
        // When the child thread reaches the breakpoint in Breakpoint(), wait for the main
        // thread to reach the One() function.  If the main thread is not there yet, squash the
        // breakpoint and move the PC back to the start of the Breakpoint() function.  This will
        // delay a while and then re-trigger the breakpoint.
        //
        ADDRINT pc = PIN_GetContextReg(ctxt, REG_INST_PTR);
        if (pc == BreakpointLocation && !AllowBreakpoint)
        {
            PIN_SetContextReg(ctxt, REG_INST_PTR, BreakpointFunction);
            GetLock(&Lock, 1);
            std::cout << "Squashing breakpoint at 0x" << std::hex << pc << " on thread " << std::dec << tid << std::endl;
            ReleaseLock(&Lock);
            return FALSE;
        }

        GetLock(&Lock, 1);
        std::cout << "Stopping at breakpoint at 0x" << std::hex << pc << " on thread " << std::dec << tid << std::endl;
        ReleaseLock(&Lock);
        return TRUE;
    }

    if (eventType == DEBUGGING_EVENT_ASYNC_BREAK)
    {
        // When the child thread triggers the breakpoint, we should be at the One() function.
        // Change the PC to the Two() function, which is the point of this test.  We want to
        // make sure Pin properly handles the change of PC in this case.
        //
        ADDRINT pc = PIN_GetContextReg(ctxt, REG_INST_PTR);
        if (pc == OneFunction)
        {
            PIN_SetContextReg(ctxt, REG_INST_PTR, TwoFunction);
            GetLock(&Lock, 1);
            std::cout << "Changing ASYNC BREAK PC to Two() on thread " << std::dec << tid << std::endl;
            ReleaseLock(&Lock);
            return TRUE;
        }

        // If the PC is not at the One() function, the child thread has probably hit some breakpoint
        // other than the one at Breakpoint().  (E.g. an internal breakpoint set by GDB.)  Don't
        // change the PC in such a case.
        //
        GetLock(&Lock, 1);
        std::cout << "ASYNC_BREAK at 0x" << std::hex << pc << " on thread " << std::dec << tid << std::endl;
        ReleaseLock(&Lock);
        return TRUE;
    }

    GetLock(&Lock, 1);
    std::cout << "FAILURE: Unexpected debugging event type" << std::endl;
    ReleaseLock(&Lock);
    std::exit(1);
}


static VOID OnExit(INT32, VOID *)
{
    if (!FoundBreakpointFunction)
    {
        std::cout << "FAILURE: Did not find Breakpoint() SYM" << std::endl;
        std::exit(1);
    }
    if (!FoundBreakpointLocation)
    {
        std::cout << "FAILURE: Did not find BreakpointLocation SYM" << std::endl;
        std::exit(1);
    }
    if (!FoundOneFunction)
    {
        std::cout << "FAILURE: Did not find One() SYM" << std::endl;
        std::exit(1);
    }
    if (!FoundTwoFunction)
    {
        std::cout << "FAILURE: Did not find Two() SYM" << std::endl;
        std::exit(1);
    }
    if (!FoundOneRtn)
    {
        std::cout << "FAILURE: Did not find One() RTN" << std::endl;
        std::exit(1);
    }
}
