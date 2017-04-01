#include <stdio.h>
#include <stdlib.h>
#include <WinSock2.h>

void ErrorHandling(char *message);

int main()
{
	WSADATA wsaData;
	struct hostent *host;
	int i = 0;

	if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0)
	{
		ErrorHandling("WSAStartup() error!");
	}

	host = gethostbyname("127.0.0.1");

	if (!host)
	{
		ErrorHandling("gethost... error");
	}

	printf("Official name: %s\n", host->h_name);

	for (i = 0; host->h_aliases[i]; i++)
	{
		printf("Aliases %d: %s\n", i + 1, host->h_aliases[i]);
	}

	printf("Address type: %s\n", (host->h_addrtype == AF_INET) ? "AF_INET" : "AF_INET6");

	for (i = 0; host->h_addr_list[i]; i++)
	{
		printf("IP addr %d: %s\n", i + 1, inet_ntoa(*(struct in_addr*)host->h_addr_list[i]));
	}

	WSACleanup();
	return 0;
}

void ErrorHandling(char *message)
{

	fputs(message, stderr);
	fputc('\n', stderr);
	exit(1);
}