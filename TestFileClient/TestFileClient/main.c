#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>

#define BUFSIZE 1024

void error_handling(char* message);

int main(int argc, char* argv[])
{
	WSADATA wsaData;
	SOCKET hSocket;
	SOCKADDR_IN servAddr;

	char message[256];
	byte buffer[BUFSIZE];
	char filename[256]="";
	int strLen;
	int strCnt;
	int i;
	int count = 0;

	FILE *file;

	/*
	if (argc != 3)
	{
	printf("Usage : %s <IP> <port>\n", argv[0]);
	exit(1);
	}
	*/

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		error_handling("WSAStartup() error!");
	}

	hSocket = socket(PF_INET, SOCK_STREAM, 0);
	if (hSocket == INVALID_SOCKET)
	{
		error_handling("socket() error");
	}

	memset(&servAddr, 0, sizeof(servAddr));
	servAddr.sin_family = AF_INET;
	servAddr.sin_addr.s_addr = inet_addr("127.0.0.1");
	servAddr.sin_port = htons(atoi("1212"));

	if (connect(hSocket, (SOCKADDR*)&servAddr, sizeof(servAddr)) == SOCKET_ERROR)
	{
		error_handling("connect() error");
	}


	printf("파일이름 : ");
	scanf("%s", filename);

	//printf("%s\n", filename);

	send(hSocket, filename, strlen(filename), 0);

	strLen = 0;

	file = fopen(filename, "wt");

	while (1)
	{
		strCnt = recv(hSocket, &buffer, BUFSIZE, 0);

		printf("%d\n", strCnt);

		if (strCnt <= 0)
		{
			fclose(file);
			//error_handling("read() error!");
			break;
		}

		fwrite(buffer, 1, strCnt, file);
	}

	closesocket(hSocket);
	WSACleanup();

	return 0;
}

void error_handling(char* message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}