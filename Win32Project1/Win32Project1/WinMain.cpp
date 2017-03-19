#include <d3d9.h>

LPDIRECT3D9 g_pD3D = NULL; // D3D ����̽��� ������ D3D ��ü ����
LPDIRECT3DDEVICE9 g_pd3dDevice = NULL; // �������� ���� D3D ����̽�

HRESULT InitD3D(HWND hWnd)
{

}

INT WINMAIN WinMain(HINSTANCE hInst, HINSTANCE, LPSTR, INT)
{
	// ������ Ŭ���� ���
	WNDCLASSEX wc = { sizeof(WNDCLASSEX),CS_CLASSDC,MsgProc, 0L, 0L,
					GetModuleHandle(NULL),NULL,NULL,NULL,NULL,
					"D3D Tutorial", NULL};
	RegisterClassEx(&wc);

	// ������ ����
	HWND hWnd = CreateWindow("D3D Tutorial", "D3D Tutorial 01: CreateDevice",
							WS_OVERLAPPEDWINDOW, 100, 100, 300, 300,
							GetDesktopWindow(), NULL, wc.hInstance, NULL);

	// Direct3D �ʱ�ȭ
	if (SUCCEEDED(InitD3D(hWnd)))
	{
		// ������ ���
		ShowWindow(hWnd, SW_SHOWDEFAULT);
		UpdateWindow(hWnd);

		// �޽��� ����
		MSG msg;
		while (GetMessage(&msg, NULL, 0, 0))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	// ��ϵ� Ŭ���� �Ұ�
	UnregisterClass("D3D Tutorial", wc.hInstance);
	return 0;
}