#include "Functions.h"

void WriteMemory(unsigned long ulAddress, unsigned char ucAmount, ...)
{
	DWORD dwOldProtect;
	VirtualProtect((void*)ulAddress, ucAmount, PAGE_EXECUTE_READWRITE, &dwOldProtect); // Unprotect memory.
	va_list* va = new va_list;
	va_start(*va, ucAmount);

	for (unsigned char ByteToWrite = va_arg(*va, unsigned char), ucIndex = 0; ucIndex < ucAmount; ucIndex++, ByteToWrite = va_arg(*va, unsigned char))
	{
		*(unsigned char*)(ulAddress + ucIndex) = ByteToWrite;
	}

	va_end(*va);
	delete va;

	VirtualProtect((void*)ulAddress, ucAmount, dwOldProtect, &dwOldProtect); // Revert back to the original.
}

bool Jump(unsigned long ulAddress, void* Function, unsigned long ulNops)
{
	__try
	{
		*(unsigned char*)ulAddress = 0xE9;
		*(unsigned long*)(ulAddress + 1) = jmp(ulAddress, Function);
		memset((void*)(ulAddress + 5), 0x90, ulNops);
		return true;
	}
	__except (EXCEPTION_EXECUTE_HANDLER) { return false; }
}

unsigned long ReadPointer(unsigned long ulBase, int iOffset)
{
	__try
	{
		return *(unsigned long*)(*(unsigned long*)ulBase + iOffset);
	}
	__except (EXCEPTION_EXECUTE_HANDLER)
	{
		return 0;
	}
}