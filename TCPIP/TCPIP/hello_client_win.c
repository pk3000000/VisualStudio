#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>
void error_handling(char* message);

int main(int argc, char* argv[])
{
	WSADATA wsaData;
	SOCKET hSocket;
	SOCKADDR_IN servAddr;

	char message[30];
	int strLen;
	int strCnt;
	int i;
	int count = 0;

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

	i = 0;

	while (i < 3)
	{
		strCnt = 0;

		recv(hSocket, &count, 4, 0);

		strLen = 0;

		while (strLen < count)
		{
			strCnt = recv(hSocket, &message[strLen], count, 0);
			
			if (strCnt == -1)
			{
				error_handling("read() error!");
			}
			strLen += strCnt;
		}
		
		message[count + 1] = '\0';

		printf("Message from server : %s\n", message);

		send(hSocket, message, 4 + count + 1, 0);
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