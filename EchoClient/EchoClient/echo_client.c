#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <WinSock2.h>

#define BUF_SIZE 1024
void ErrorHanding(char *message);

int main()
{
	WSADATA wsaData;
	SOCKET hSocket;
	char message[BUF_SIZE];
	int strLen;
	SOCKADDR_IN servAdr;
	int recvLen;
	int recvCnt;

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		ErrorHanding("WSAStartup() error!");
	}

	hSocket = socket(PF_INET, SOCK_STREAM, 0);
	if (hSocket == INVALID_SOCKET)
	{
		ErrorHanding("socket() error!");
	}

	memset(&servAdr, 0, sizeof(servAdr));
	servAdr.sin_family = AF_INET;
	servAdr.sin_addr.s_addr = inet_addr("127.0.0.1");
	servAdr.sin_port = htons(atoi("9191"));

	if (connect(hSocket, (SOCKADDR*)&servAdr, sizeof(servAdr)) == SOCKET_ERROR)
	{
		ErrorHanding("connect() error!");
	}
	else
	{
		puts("Connected.......");
	}

	while (1)
	{
		fputs("Input message(Q to quit): ", stdout);
		fgets(message, BUF_SIZE, stdin);

		if (!strcmp(message, "q\n") || !strcmp(message, "Q\n"))
		{
			break;
		}

		strLen = send(hSocket, message, strlen(message), 0);
		
		recvLen = 0;

		while (recvLen < strLen)
		{
			recvCnt= recv(hSocket, &message[recvLen], BUF_SIZE - 1,0);
			if (recvCnt == -1)
			{
				ErrorHanding("read() error!");
			}
			recvLen += recvCnt;
		}

		message[recvLen] = 0;
		printf("Message from server: %s", message);
	}
	closesocket(hSocket);
	WSACleanup();
	return 0;
}

void ErrorHanding(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}