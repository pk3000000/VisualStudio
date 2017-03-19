#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>

#define BUFSIZE 1024

void error_handling(char *message);


int main(int argc, char *argv[])
{
	WSADATA wsaData;
	SOCKET hServSock, hClntSock;
	SOCKADDR_IN servAddr, clntAddr;

	int szClntAddr;
	char filename[256] = "";
	byte buffer[BUFSIZE];
	int count = 0;
	int strLen = 0;
	int strCnt = 0;
	int fileLen = 0;
	int i = 0;

	FILE *file;


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

	recv(hClntSock, &filename, 256, 0);

	filename[strlen(filename)] = '\0';

	printf("%s\n", filename);

	file = fopen(filename, "rt");

	if (file == NULL)
	{
		closesocket(hClntSock);
	}
	else
	{

		while (1)
		{
			strCnt = fread(buffer,1,BUFSIZE,file);

			printf("%d\n", strCnt);

			if (strCnt < BUFSIZE)
			{
				send(hClntSock, buffer, strCnt, 0);
				fclose(file);
				closesocket(hClntSock);
				break;
			}
			send(hClntSock, buffer, strCnt, 0);
		}
	}
	

	
//	closesocket(hClntSock);
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