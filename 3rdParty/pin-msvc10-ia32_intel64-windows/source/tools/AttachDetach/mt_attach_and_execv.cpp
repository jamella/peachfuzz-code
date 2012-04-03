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
#include <assert.h>
#include <stdio.h>
#include <dlfcn.h>
#include <signal.h>
#include <sys/types.h>
#include <linux/unistd.h>
#include <pthread.h>
#include <sys/wait.h>
#include <stdlib.h>
#include <string>
#include <list>
#include <syscall.h>


using namespace std;

/* 
 * The total number of threads that should run in this process
 * The number may be changed in command line with -th_num
 */
unsigned int numOfSecondaryThreads = 4;

/*
 * An endless-loop function for secondary threads
 */

void * ThreadEndlessLoopFunc(void * arg)
{
    int x = 0;
    while (1) 
    {
        x++;
        if (x > 10) 
        {
            x = 0;
        }
    }

    return 0;
}

#define DECSTR(buf, num) { buf = (char *)malloc(10); sprintf(buf, "%d", num); }

inline void PrintArguments(char **inArgv)
{
    fprintf(stderr, "Going to run: ");
    for(unsigned int i=0; inArgv[i] != 0; ++i)
    {
        fprintf(stderr, "%s ", inArgv[i]);
    }
    fprintf(stderr, "\n");
}


/* AttachAndInstrument()
 * a special thread routine that runs $PIN
 */
void * AttachAndInstrument(void *arg)
{
    list <string > * pinArgs = (list <string > *)arg;
    list <string >::iterator pinArgIt = pinArgs->begin();

    string pinBinary = *pinArgIt;
    pinArgIt++;

    pid_t parent_pid = getpid();
    
    pid_t child = fork();

    if (child) 
    {
        // inside parent
		int status = 0;
		while (1)
		{
			pid_t pid = waitpid(child, &status, WNOHANG);
			if (pid == 0)
			{
				fprintf(stderr, ".");
				sleep(2);
				continue;
			}
			if (WIFEXITED(status) && (WEXITSTATUS(status)==0))
			{
				fprintf(stderr, "Pin injector works correctly\n");
				return 0;
			}
			else if (WIFEXITED(status) || WIFSTOPPED(status) || WIFSIGNALED(status))
			{
				fprintf(stderr, "Pin injector failed\n");
				exit(-1);
			}
		}
        return 0;  
    }
    else
    {
        // inside child

        char **inArgv = new char*[pinArgs->size()+10];

        unsigned int idx = 0;
        inArgv[idx++] = (char *)pinBinary.c_str(); 
        inArgv[idx++] = (char*)"-pid"; 
        inArgv[idx] = (char *)malloc(10);
        sprintf(inArgv[idx++], "%d", parent_pid);

        for (; pinArgIt != pinArgs->end(); pinArgIt++)
        {
            inArgv[idx++]= (char *)pinArgIt->c_str();
        }
        inArgv[idx] = 0;
        
        PrintArguments(inArgv);

        execvp(inArgv[0], inArgv);
        fprintf(stderr, "ERROR: execv %s failed\n", inArgv[0]);
        return (void *)-1;
    }
}

/*
 * Expected command line: <this exe> [-th_num NUM] -pin $PIN -pinarg <pin args > -t tool <tool args>
 */

void ParseCommandLine(int argc, char *argv[], list < string>* pinArgs)
{
    string pinBinary;
    for (int i=1; i<argc; i++)
    {
        string arg = string(argv[i]);
        if (arg == "-th_num")
        {
            numOfSecondaryThreads = atoi(argv[++i]) - 1;
        }
        else if (arg == "-pin")
        {
            pinBinary = argv[++i];
        }
        else if (arg == "-pinarg")
        {
            for (int parg = ++i; parg < argc; parg++)
            {
                pinArgs->push_back(string(argv[parg]));
                ++i;
            }
        }
    }
	if (numOfSecondaryThreads == 0) 
		return;
    assert(!pinBinary.empty());
    pinArgs->push_front(pinBinary);
}


extern "C" int ThreadsReady(unsigned int numOfThreads)
{
	assert(numOfThreads == numOfSecondaryThreads+1);
	return 0;
}
	
extern "C" int MainThreadReady()
{
	return 0;
}

int main(int argc, char *argv[])
{
	numOfSecondaryThreads = 0;
	
    list <string> pinArgs;
    ParseCommandLine(argc, argv, &pinArgs);
	
	if (numOfSecondaryThreads == 0)
		return 0;
    
    pthread_t *thHandle = new pthread_t[numOfSecondaryThreads];

    // start all secondary threads
    for (unsigned int i = 0; i < numOfSecondaryThreads; i++)
    {
        pthread_create(&thHandle[i], 0, ThreadEndlessLoopFunc, (void *)0);
    }

    pthread_t attachThread;
    pthread_create(&attachThread, 0, AttachAndInstrument, &pinArgs);
	

	while(!MainThreadReady())
	{
        fprintf(stderr, ".");
        sleep(1);
	}
	fprintf(stderr, "Main thread is ready, going to exec\n");
	
	if (execl("./badexec.sh", "./badexec.sh", NULL) == -1)
	{
		fprintf(stderr, "badexec failed, proceeding ..\n");
		//return -1;
	}
	
	// run the same app w/o params
	char **inArgv = new char*[3];
	inArgv[0] = argv[0];
	inArgv[1] = 0;
	    
	if (execl(inArgv[0], inArgv[0], NULL) == -1)
	{
		fprintf(stderr, "execve failed, exiting ..\n");
		return -1;
	}
    
	// Wait for all threads 
    while (!ThreadsReady(numOfSecondaryThreads+1))
	{
        fprintf(stderr, ".");
        sleep(2);
    }		
		
    return 0;
}

