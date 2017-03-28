#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <WinSock2.h>

#define BUF_SIZE 30

void ErrorHanding(char *message);

int main()
{
	WSADATA wsaData;
	SOCKET servSock;
	char message[BUF_SIZE];
	int strLen;
	int clntAdrSz;

	SOCKADDR_IN servAdr, clntAdr;

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		ErrorHanding("WSAStartup() error!");
	}

	servSock = socket(PF_INET, SOCK_DGRAM, 0);

	if (servSock == INVALID_SOCKET)
	{
		ErrorHanding("UDP socket creation error");
	}

	memset(&servAdr, 0, sizeof(servAdr));
	servAdr.sin_family = AF_INET;
	servAdr.sin_addr.s_addr = htonl(INADDR_ANY);
	servAdr.sin_port = htons(atoi("9191"));

	if (bind(servSock, (SOCKADDR*)&servAdr, sizeof(servAdr)) == SOCKET_ERROR)
	{
		ErrorHanding("bind() error");
	}

	while (1)
	{
		clntAdrSz = sizeof(clntAdr);
		strLen = recvfrom(servSock, message, BUF_SIZE, 0,
			(SOCKADDR*)&clntAdr, &clntAdrSz);
		sendto(servSock, message, strLen, 0,
			(SOCKADDR*)&clntAdr, sizeof(clntAdr));
	}
	closesocket(servSock);
	WSACleanup();
	return 0;
}


void ErrorHanding(char * message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}