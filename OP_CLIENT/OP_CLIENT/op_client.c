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
	char buf[BUF_SIZE];
	int strLen;
	SOCKADDR_IN servAdr;
	int recvLen;
	int op_count;
	char op[2];
	char en;
	int result = 0;


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
	servAdr.sin_port = htons(atoi("9090"));

	if (connect(hSocket, (SOCKADDR*)&servAdr, sizeof(servAdr)) == SOCKET_ERROR)
	{
		ErrorHanding("connect() error!");
	}
	else
	{
		puts("Connected.......");
	}

	
	fputs("Operand count:", stdout);
	scanf("%d", &op_count);

	message[0] = (char)op_count;

	//send(hSocket, message, strlen(message), 0);

	for (int i = 0; i < op_count; i++)
	{
		fprintf(stdout,"Operand %d :", i+1);
		scanf("%d",(int*)&message[i*4+1]);
		//send(hSocket, message, strlen(message), 0);
	}
	fgetc(stdin);

	fprintf(stdout, "Operator :");
	scanf("%c", &message[op_count * 4 + 1]);

	printf("%c\n", message[op_count * 4 + 1]);

	send(hSocket, message, op_count*4+2, 0);
	recvLen = recv(hSocket, &result, 4, 0);

	if (recvLen == -1)
	{
		ErrorHanding("read() error!");
	}

	printf("Operand result : %d\n", result);
	
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