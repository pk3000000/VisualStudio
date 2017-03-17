#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <WinSock2.h>

#define BUF_SIZE 1024
void ErrorHandling(char *message);
int calculate(int opnum, int opnds[], char op);

int main()
{
	WSADATA wsaData;
	SOCKET hServSock, hClntSock;
	char message[BUF_SIZE];
	char buf[BUF_SIZE];
	int strLen=0, i=0;
	char c_op_count='\0';
	int op_count=0;
	int operand[100] = { 0, };
	char op='\0';
	int result=0;
	int recvLen=0;
	int recvCnt=0;

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

	recv(hClntSock, &op_count, 1, 0);

	printf("%d\n", op_count);

	recvLen = 0;

	while(op_count*4+1>recvLen)
	{
		recvCnt=recv(hClntSock, &message[recvLen], BUF_SIZE-1, 0);
		recvLen += recvCnt;
	}

	result = calculate(op_count, (int*)message, message[recvLen - 1]);

	send(hClntSock, &result, sizeof(result), 0);
	
	hClntSock = accept(hServSock, (SOCKADDR*)&clntAdr, &clntAdrSize);

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

int calculate(int opnum, int opnds[], char op)
{
	int result = opnds[0], i;

	printf("%d\n", opnds[1]);

	switch (op)
	{
	case '+':
		for (i = 1; i < opnum; i++) result += opnds[i];
		break;
	case '-':
		for (i = 1; i < opnum; i++) result -= opnds[i];
		break;
	case '*':
		for (i = 1; i < opnum; i++) result *= opnds[i];
		break;
	case '/':
		for (i = 1; i < opnum; i++) result /= opnds[i];
		break;
	}

	return result;
}