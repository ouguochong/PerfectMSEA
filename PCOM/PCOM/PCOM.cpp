#include "PCOM.h"

namespace PCOM 
{
	DWORD dwDllCanUnloadNow;
	DWORD dwDllGetClassObject;
	DWORD dwPcCreateObject;
	DWORD dwPcFreeUnusedLibraries;
	DWORD dwPcInitModule;
	DWORD dwPcPassPackIgnoreProp;
	DWORD dwPcRootNameSpace;
	DWORD dwPcSerializeObject;
	DWORD dwPcSerializeString;
	DWORD dwPcTermModule;
}

void _declspec(naked) PCOM_DllCanUnloadNow() { _asm jmp dword ptr[PCOM::dwDllCanUnloadNow] }
void _declspec(naked) PCOM_DllGetClassObject() { _asm jmp dword ptr[PCOM::dwDllGetClassObject] }
void _declspec(naked) PCOM_PcCreateObject() { _asm jmp dword ptr[PCOM::dwPcCreateObject] }
void _declspec(naked) PCOM_PcFreeUnusedLibraries() { _asm jmp dword ptr[PCOM::dwPcFreeUnusedLibraries] }
void _declspec(naked) PCOM_PcInitModule() { _asm jmp dword ptr[PCOM::dwPcInitModule] }
void _declspec(naked) PCOM_PcPassPackIgnoreProp() { _asm jmp dword ptr[PCOM::dwPcPassPackIgnoreProp] }
void _declspec(naked) PCOM_PcRootNameSpace() { _asm jmp dword ptr[PCOM::dwPcRootNameSpace] }
void _declspec(naked) PCOM_PcSerializeObject() { _asm jmp dword ptr[PCOM::dwPcSerializeObject] }
void _declspec(naked) PCOM_PcSerializeString() { _asm jmp dword ptr[PCOM::dwPcSerializeString] }
void _declspec(naked) PCOM_PcTermModule() { _asm jmp dword ptr[PCOM::dwPcTermModule] }

BOOL PCOM::Initialization() 
{
	HMODULE PCOM;

	PCOM = LoadLibraryA("PCOM.proxy");

	if (PCOM == 0) 
	{
		Error("Couldn't load PCOM.proxy, Thank you!", TRUE);
		return FALSE;
	}

	dwDllCanUnloadNow = (DWORD)GetProcAddress(PCOM, "DllCanUnloadNow");
	dwDllGetClassObject = (DWORD)GetProcAddress(PCOM, "DllGetClassObject");
	dwPcCreateObject = (DWORD)GetProcAddress(PCOM, "PcCreateObject");
	dwPcFreeUnusedLibraries = (DWORD)GetProcAddress(PCOM, "PcFreeUnusedLibraries");
	dwPcInitModule = (DWORD)GetProcAddress(PCOM, "PcInitModule");
	dwPcPassPackIgnoreProp = (DWORD)GetProcAddress(PCOM, "PcPassPackIgnoreProp");
	dwPcRootNameSpace = (DWORD)GetProcAddress(PCOM, "PcRootNameSpace");
	dwPcSerializeObject = (DWORD)GetProcAddress(PCOM, "PcSerializeObject");
	dwPcSerializeString = (DWORD)GetProcAddress(PCOM, "PcSerializeString");
	dwPcTermModule = (DWORD)GetProcAddress(PCOM, "PcTermModule");

	if (dwDllCanUnloadNow == NULL || dwDllGetClassObject == NULL || dwPcCreateObject == NULL || dwPcFreeUnusedLibraries == NULL || dwPcInitModule == NULL || dwPcPassPackIgnoreProp == NULL || dwPcRootNameSpace == NULL || dwPcSerializeObject == NULL || dwPcSerializeString == NULL || dwPcTermModule == NULL) 
	{
		Error("Couldn't find PCOM.proxy's function, Thank you!", TRUE);
		return FALSE;
	}

	return TRUE;
}


void PCOM::Error(char message[], BOOL kill) 
{
	MessageBoxA(NULL, message, "PCOM.proxy", MB_OK);
	if (kill == TRUE) 
	{
		ExitProcess(0);
	}
}