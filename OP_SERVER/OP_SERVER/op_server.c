#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <WinSock2.h>

#define BUF_SIZE 1024
void ErrorHandling(char *message);

int main()
{
	WSADATA wsaData;
	SOCKET hServSock, hClntSock;
	char message[BUF_SIZE];
	char buf[BUF_SIZE];
	int strLen, i;
	int op_count;
	int operand[100] = { 0, };
	char op;
	int result;

	SOCKADDR_IN servAdr, clntAdr;
	int clntAdrSize;

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		ErrorHandling("WSAStartup() error!");
	}

	hServSock = socket(PF_INET, SOCK_STREAM, 0);
	if (hServSock == INVALID_SOCKET)
	{
		ErrorHandling("socket() error!");
	}

	memset(&servAdr, 0, sizeof(servAdr));
	servAdr.sin_family = AF_INET;
	servAdr.sin_addr.s_addr = htonl(INADDR_ANY);
	servAdr.sin_port = htons(atoi("9090"));

	if (bind(hServSock, (SOCKADDR*)&servAdr, sizeof(servAdr)) == SOCKET_ERROR)
	{
		ErrorHandling("bind() error!");
	}

	if (listen(hServSock, 5) == SOCKET_ERROR)
	{
		ErrorHandling("listen() error!");
	}

	clntAdrSize = sizeof(clntAdr);

	
	hClntSock = accept(hServSock, (SOCKADDR*)&clntAdr, &clntAdrSize);
	if (hClntSock == -1)
	{
		ErrorHandling("accept() error!");
	}
	else
	{
		printf("Connected client %d \n", 1);
	}

	recv(hClntSock, message, BUF_SIZE, 0);
		
	op_count = atoi(message);

	for (int i = 0; i < op_count; i++)
	{
		recv(hClntSock, message, BUF_SIZE, 0);
		operand[i] = atoi(message);
		printf("%d\n", operand[i]);
	}

	recv(hClntSock, message, BUF_SIZE, 0);

	op = message[0];
	result = operand[0];

	for (int i = 1; i < op_count; i++)
	{
		switch (op)
		{
		case '+':
			result += operand[i];
			break;
		case '-':
			result -= operand[i];
			break;
		case '*':
			result *= operand[i];
			break;
		case '/':
			result /= operand[i];
			break;
		}
	}

	itoa(result, buf, 10);

	printf("%s\n", buf);

	send(hClntSock, buf, strlen(buf), 0);
		
	closesocket(hClntSock);

	closesocket(hServSock);
	WSACleanup();
	return 0;
}

void ErrorHandling(char *message)
{
	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}