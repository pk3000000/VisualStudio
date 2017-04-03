#include <stdio.h>
#include <windows.h>
#include <process.h>

#define NUM_THREAD 50
unsigned WINAPI threadInc(void * arg);
unsigned WINAPI threadDes(void * arg);

long long num = 0;
HANDLE hMutex;

int main()
{
	HANDLE tHandle[NUM_THREAD];
	int i;

	hMutex = CreateMutex(NULL, FALSE, NULL);
	for (i = 0; i < NUM_THREAD; i++)
	{
		if (i % 2)
		{
			tHandle[i] = (HANDLE)_beginthreadex(NULL, 0, threadInc, NULL, 0, NULL);
		}
		else
		{
			tHandle[i] = (HANDLE)_beginthreadex(NULL, 0, threadDes, NULL, 0, NULL);
		}
	}

	WaitForMultipleObjects(NUM_THREAD, tHandle, TRUE, INFINITE);
	CloseHandle(hMutex);
	printf("result: %lld\n", num);

	return 0;
}

unsigned WINAPI threadInc(void * arg)
{
	int i;
	WaitForSingleObject(hMutex, INFINITE);
	for (i = 0; i < 50000000; i++)
	{
		num += 1;
	}
	ReleaseMutex(hMutex);
	return 0;
}

unsigned WINAPI threadDes(void * arg)
{
	int i;
	WaitForSingleObject(hMutex, INFINITE);
	for (i = 0; i < 50000000; i++)
	{
		num -= 1;
	}
	ReleaseMutex(hMutex);
	return 0;
}