#include "Definitions.h"

VOID MessageHandler(__in PPIPE_MESSAGE pInMessage, __out PPIPE_MESSAGE pOutMessage)
{
	int optionValue = *(int *)pInMessage->Data;
	int &outputValue = *(int *)pOutMessage->Data;
	switch (pInMessage->ControlCode)
	{
		// Information
		case PEOPLE_COUNT:
			outputValue = GetPeopleCount();
			break;
		case MOB_COUNT:
			outputValue = GetMobCount();
			break;

		// Bots
		case AUTO_LOOT:
			AutoLoot(optionValue);
			break;

		// CPU Hacks
		case NO_BACKGROUND:
			NoBackground(optionValue);
			break;
		case NO_DAMAGE_TEXT:
			NoDamageText(optionValue);
			break;

		// Char Hacks
		case STANCE_HACK:
			StanceHack(optionValue);
			break;
		case ITEM_FILTER:
			ItemFilter(optionValue);
			break;
		case PERFECT_LOOT:
			PerfectLoot(optionValue);
			break;
		case UNLIMITED_ATTACK:
			UnlimitedAttack(optionValue);
			break;

		// Mob Hacks
		case MOB_FREEZE:
			MobFreeze(optionValue);
			break;
		case MOB_DISARM:
			MobDisarm(optionValue);
			break;
		case MOB_ITEM_VAC:
			MobItemVac(optionValue);
			break;
		case MOB_VAC:
			MobVac(optionValue);
			break;
		case MOB_VAC_TYPE:
			MobVac_SetType(optionValue);
			break;

		// Misc. Hacks
		case SKILL_INJECTION:
			SkillInjection(optionValue);
			break;
		case SKILL_INJECTION_SPEED:
			SkillInjection_SetSpeed(optionValue);
			break;
	}
}

DWORD WINAPI ServerThread(LPVOID lpvParam)
{
	CPipeServer *server = reinterpret_cast<CPipeServer *>(lpvParam);

	if (!server->Run())
		return (DWORD)-1;

	return 1;
}

void Main()
{
	MessageBeep(MB_ICONINFORMATION);

	CPipeServer server;
	HANDLE hThread;
	DWORD dwExitCode;

	async_ostream::init();

	server.SetName(L"\\\\.\\pipe\\PerfectMSEA");
	server.SetInBufferSize(1024);
	server.SetOutBufferSize(1024);
	server.SetMessageHandler(MessageHandler);

	hThread = CreateThread(NULL, 0, ServerThread, reinterpret_cast<LPVOID>(&server), 0, NULL);
	do
	{
		Sleep(50);
		GetExitCodeThread(hThread, &dwExitCode);
	} while (dwExitCode == STILL_ACTIVE);
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {

	if (fdwReason != DLL_PROCESS_ATTACH) { return FALSE; }
	if (PCOM::Initialization()) 
	{
		NewThread(Main);
		WriteMemory(ThemidaCRC_Addy, 3, 0x33, 0xC0, 0xC3); // Bypasses Themida Checks
		WriteMemory(LogoSkipper_Addy, 1, 0x75);
	}
	else 
	{
		return FALSE;
	}

	return TRUE;
}