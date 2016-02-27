#ifndef PIPESERVER_H
#define PIPESERVER_H

#include "PipeServerStruct.h"
#include <Windows.h>
#include <vector>
using namespace std;

class CPipeServer
{
	public:
		typedef VOID(*PIPE_MESSAGE_HANDLER)(__in PPIPE_MESSAGE pInMessage, __out PPIPE_MESSAGE pOutMessage);

		typedef struct
		{
			HANDLE Pipe;
			CPipeServer *Server;
		} PIPE_INSTANCE, *PPIPE_INSTANCE;

		CPipeServer();
		virtual ~CPipeServer() { dtor(); }

		VOID SetName(LPCTSTR Name);
		VOID SetTimeOut(DWORD TimeOut);
		VOID SetMessageHandler(PIPE_MESSAGE_HANDLER MessageHandler);
		VOID SetOutBufferSize(DWORD OutBufferSize);
		VOID SetInBufferSize(DWORD InBufferSize);
		VOID SetRunning(BOOL Running);

		LPCTSTR GetName() { return Name; }
		DWORD GetTimeOut() { return TimeOut; }
		PIPE_MESSAGE_HANDLER GetMessageHandler() { return MessageHandler; }
		DWORD GetOutBufferSize() { return OutBufferSize; }
		DWORD GetInBufferSize() { return InBufferSize; }
		BOOL IsRunning() { return Running; }

		BOOL Run();

	private:
		vector<HANDLE> m_Clients;
		PIPE_MESSAGE m_InMessage;
		PIPE_MESSAGE m_OutMessage;
		CRITICAL_SECTION m_CriticalSection;

		LPCTSTR Name;
		DWORD TimeOut;
		PIPE_MESSAGE_HANDLER MessageHandler;
		DWORD OutBufferSize;
		DWORD InBufferSize;
		BOOL Running;

		VOID dtor();
		VOID reset();
		VOID WaitClients();
		static DWORD WINAPI InstanceThread(LPVOID lpvParam);
};

#endif // PIPESERVER_H
