#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>

void error_handling(char *message);

int main(int argc, char *argv[])
{
	WSADATA wsaData;
	SOCKET hServSock, hClntSock;
	SOCKADDR_IN servAddr, clntAddr;

	int szClntAddr;
	char message[1024] = "Hello?";
	int count = 0;
	int strLen = 0;
	int strCnt = 0;
	int i = 0;
/*
	if (argc != 2)
	{
		printf("Usage : %s <port>\n", argv[0]);
		exit(1);
	}
	*/
	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		error_handling("WSAStartup() error!");
	}

	hServSock = socket(PF_INET, SOCK_STREAM, 0);
	if (hServSock == INVALID_SOCKET)
	{
		error_handling("socket() error");
	}

	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family = AF_INET;
	servAddr.sin_addr.s_addr = htonl(INADDR_ANY);
	servAddr.sin_port = htons(atoi("1212"));

	if (bind(hServSock, (SOCKADDR*)&servAddr, sizeof(servAddr)) == SOCKET_ERROR)
	{
		error_handling("bind() error");
	}

	if (listen(hServSock, 5) == SOCKET_ERROR)
	{
		error_handling("listen() error");
	}

	szClntAddr = sizeof(clntAddr);
	hClntSock = accept(hServSock, (SOCKADDR*)&clntAddr, &szClntAddr);
	if (hClntSock == INVALID_SOCKET)
	{
		error_handling("accept() error");
	}
	
	count = strlen(message);

	send(hClntSock, (char*)&count, 4, 0);

	while (i < 3)
	{
		strLen = 0;

		send(hClntSock, message, strlen(message)+1, 0);

		while (strLen < count-1)
		{
			strCnt = recv(hClntSock,&message[strLen],count+1,0);
			if (strCnt == -1)
			{
				error_handling("recv() error!");
			}
			strLen += strCnt;
		}

		message[strLen] = '\0';

		printf("%s\n", message);

		i++;
	}
	

	closesocket(hClntSock);
	closesocket(hServSock);
	WSACleanup();

	return 0;
}

void error_handling(char* message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}