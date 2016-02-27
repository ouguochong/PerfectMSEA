#include "PipeServer.h"

CPipeServer::CPipeServer()
{
	InitializeCriticalSection(&m_CriticalSection);
	m_InMessage.Data = NULL;
	m_OutMessage.Data = NULL;
	reset();
}

VOID CPipeServer::dtor()
{
	reset();
	WaitClients();
	DeleteCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetName(LPCTSTR Name)
{
	EnterCriticalSection(&m_CriticalSection);
	this->Name = Name;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetTimeOut(DWORD TimeOut)
{
	EnterCriticalSection(&m_CriticalSection);
	this->TimeOut = TimeOut;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetMessageHandler(PIPE_MESSAGE_HANDLER MessageHandler)
{
	EnterCriticalSection(&m_CriticalSection);
	this->MessageHandler = MessageHandler;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetOutBufferSize(DWORD OutBufferSize)
{
	EnterCriticalSection(&m_CriticalSection);
	this->OutBufferSize = OutBufferSize;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetInBufferSize(DWORD InBufferSize)
{
	EnterCriticalSection(&m_CriticalSection);
	this->InBufferSize = InBufferSize;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::SetRunning(BOOL Running)
{
	EnterCriticalSection(&m_CriticalSection);
	this->Running = Running;
	LeaveCriticalSection(&m_CriticalSection);
}

VOID CPipeServer::reset()
{
	EnterCriticalSection(&m_CriticalSection);
	Name = NULL;
	TimeOut = 0;
	OutBufferSize = 1024;
	InBufferSize = 1024;
	LeaveCriticalSection(&m_CriticalSection);
}

BOOL CPipeServer::Run()
{
#ifdef _DEBUG
	WCHAR lpcwError[256] = { 0 };
#endif
	BOOL Connected;
	DWORD dwThreadId = 0;
	HANDLE hPipe = INVALID_HANDLE_VALUE, hThread = NULL;
	PPIPE_INSTANCE pPipeInstance;

	assert(Name != NULL);
	assert(MessageHandler != NULL);
	SetRunning(TRUE);

	while (Running)
	{
		hPipe = CreateNamedPipe(Name, PIPE_ACCESS_DUPLEX, PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT,
			PIPE_UNLIMITED_INSTANCES, OutBufferSize, InBufferSize, TimeOut, NULL);

		if (hPipe == INVALID_HANDLE_VALUE)
		{
#ifdef _DEBUG
			wsprintf(lpcwError, L"Could not create pipe. GetLastError = %d", GetLastError());
			MessageBoxW(NULL, lpcwError, L"CPipeServer", 0);
#endif
			return FALSE;
		}

		Connected = ConnectNamedPipe(hPipe, NULL) ? TRUE : (GetLastError() == ERROR_PIPE_CONNECTED);

		if (Connected)
		{
			pPipeInstance = new PIPE_INSTANCE;
			pPipeInstance->Server = this;
			pPipeInstance->Pipe = hPipe;

			hThread = CreateThread(NULL, 0, InstanceThread, reinterpret_cast<LPVOID>(pPipeInstance), 0, &dwThreadId);

			if (hThread == NULL)
			{
#ifdef _DEBUG
				wsprintf(lpcwError, L"CreateThread failed. GetLastError = %d", GetLastError());
				MessageBoxW(NULL, lpcwError, L"CPipeServer", 0);
#endif
				delete pPipeInstance;
				return FALSE;
			}
		}
		else
			if (hPipe != INVALID_HANDLE_VALUE && hPipe)
				CloseHandle(hPipe);
	}

	WaitClients();
	return TRUE;
}

VOID CPipeServer::WaitClients()
{
	EnterCriticalSection(&m_CriticalSection);
	while (m_Clients.size())
	{
		WaitForSingleObject(m_Clients[0], INFINITE);
		CloseHandle(m_Clients[0]);
		m_Clients.erase(m_Clients.begin());
	}
	LeaveCriticalSection(&m_CriticalSection);
}

DWORD WINAPI CPipeServer::InstanceThread(LPVOID lpvParam)
{
	WCHAR lpcwError[256] = { 0 };
	PPIPE_INSTANCE pInstance = reinterpret_cast<PPIPE_INSTANCE>(lpvParam);
	PIPE_MESSAGE InMessage = { 0 }, OutMessage = { 0 };
	LPVOID RawData = NULL;

	DWORD cbRead = 0, cbWritten = 0;
	BOOL Success = FALSE;

	InMessage.Data = pInstance->Server->GetInBufferSize() ? new UCHAR[pInstance->Server->GetInBufferSize()] : NULL;
	OutMessage.Data = pInstance->Server->GetOutBufferSize() ? new UCHAR[pInstance->Server->GetOutBufferSize()] : NULL;

	assert(lpvParam != NULL);
	assert(pInstance->Server->GetMessageHandler() != NULL);

	while (true)
	{
		delete[](PUCHAR)RawData;
		RawData = new UCHAR[pInstance->Server->GetInBufferSize() + sizeof(DWORD)];
		SecureZeroMemory(RawData, pInstance->Server->GetInBufferSize() + sizeof(DWORD));
		Success = ReadFile(pInstance->Pipe, RawData, pInstance->Server->GetInBufferSize() + sizeof(DWORD), &cbRead, NULL);

		if (!Success || cbRead == 0)
		{
#ifdef _DEBUG
			if (GetLastError() != ERROR_BROKEN_PIPE)
			{
				// Client disconnected or errored
				wsprintf(lpcwError, L"Could not create pipe. GetLastError = %d", GetLastError());
				MessageBoxW(NULL, lpcwError, L"CPipeServer", 0);
			}
#endif

			break;
		}

		InMessage.ControlCode = *(DWORD *)RawData;
		OutMessage.ControlCode = *(DWORD *)RawData;

		if (OutMessage.Data)
			SecureZeroMemory(OutMessage.Data, pInstance->Server->GetOutBufferSize());

		if (InMessage.Data)
			memcpy(InMessage.Data, (PUCHAR)RawData + sizeof(DWORD), pInstance->Server->GetInBufferSize());

		delete[](PUCHAR)RawData;

		pInstance->Server->GetMessageHandler()(&InMessage, &OutMessage);

		RawData = new UCHAR[pInstance->Server->GetOutBufferSize() + sizeof(DWORD)];
		SecureZeroMemory(RawData, pInstance->Server->GetOutBufferSize() + sizeof(DWORD));
		memcpy(RawData, &OutMessage.ControlCode, sizeof(DWORD));

		if (OutMessage.Data)
			memcpy((PUCHAR)RawData + sizeof(DWORD), OutMessage.Data, pInstance->Server->GetOutBufferSize());

		Success = WriteFile(pInstance->Pipe, RawData, pInstance->Server->GetOutBufferSize() + sizeof(DWORD),
			&cbWritten, NULL);

		if (!Success || pInstance->Server->GetOutBufferSize() + sizeof(DWORD) != cbWritten)
		{
#ifdef _DEBUG
			wsprintf(lpcwError, L"InstanceThread: WriteFile to pipe failed. GetLastError = %d", GetLastError());
			MessageBoxW(NULL, lpcwError, L"CPipeServer", 0);
#endif
			break;
		}
	}

	FlushFileBuffers(pInstance->Pipe);
	DisconnectNamedPipe(pInstance->Pipe);

	if (pInstance->Pipe != INVALID_HANDLE_VALUE && pInstance->Pipe)
		CloseHandle(pInstance->Pipe);

	delete[](PUCHAR)RawData;
	delete[](PUCHAR)InMessage.Data;
	delete[](PUCHAR)OutMessage.Data;
	delete pInstance;

	return 1;
}
