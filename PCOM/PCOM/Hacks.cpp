#include "Hacks.h"

// Information
int GetPeopleCount()
{
	return ReadPointer(TSingleton__CUserPool, PeopleCount_Offset);
}

int GetMobCount()
{
	return ReadPointer(TSingleton__CMobPool, MobCount_Offset);
}

// CPU Hacks
void NoBackground(bool toggle)
{
	if (toggle)
	{
		WriteMemory(NoBackground_Addy, 5, 0x90, 0x90, 0x90, 0x90, 0x90);
	}
	else
	{
		WriteMemory(NoBackground_Addy, 5, 0x8B, 0x75, 0x04, 0x3B, 0xF7);
	}
}

void NoDamageText(bool toggle)
{
	if (toggle)
	{
		WriteMemory(NoDamageText_Addy, 7, 0xC2, 0x58, 0x00, 0x90, 0x90, 0x90, 0x90);
	}
	else
	{
		WriteMemory(NoDamageText_Addy, 7, 0x6A, 0xFF, 0x68, 0x08, 0x95, 0x68, 0x01);
	}
}

// Char Hacks
void StanceHack(bool toggle)
{
	if (toggle) 
	{
		WriteMemory(StanceHack_Addy, 1, 0x00);
	}
	else 
	{
		WriteMemory(StanceHack_Addy, 1, 0x01);
	}
}

DWORD Filter_ItemList[18000];
DWORD ItemFilter_ReturnAddy = ItemFilter_Addy + 0x5;
__declspec(naked) void __stdcall ItemFilter_Accept_CC()
{
	__asm
	{
		push edx
		mov edx, 0x64 // minimum 100 mesos
		cmp eax, edx
		jle FilterMesos
		mov edx, offset[Filter_ItemList]
		jmp AcceptFilter

		FilterMesos :
		mov[esi + 0x44], 0
		jmp End

		AcceptFilter :
		cmp eax, [edx]
		je End
		cmp dword ptr[edx], 0
		je Ignore
		add edx, 4
		jmp AcceptFilter

		Ignore :
		cmp eax, 0x0000EA60 // Added this code otherwise mesos is dropped but not shown in accept mode
		jle End
		mov eax, 0

		End :
		pop edx
		mov ecx, ebx // Original Opcode
		mov[esi + 0x48], eax // Original Opcode
		jmp dword ptr[ItemFilter_ReturnAddy]
	}
}

void ItemFilter(bool toggle)
{
	if (toggle) 
	{
		Filter_ItemList[0] = 0x2518C6; // Medal of honor
		Filter_ItemList[1] = 0x00; // ends list		
		Jump(ItemFilter_Addy, ItemFilter_Accept_CC, 0);
	}
	else 
	{
		WriteMemory(ItemFilter_Addy, 5, 0x8B, 0xCB, 0x89, 0x46, 0x48);
	}
}

void PerfectLoot(bool toggle)
{
	if (toggle)
	{
		WriteMemory(Tubi_Addy, 6, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
		WriteMemory(InstantDrop_Addy, 2, 0xDC, 0x25);
		WriteMemory(NoLootAnimation_Addy, 6, 0x81, 0xFE, 0x00, 0x00, 0x00, 0x00);
	}
	else
	{
		WriteMemory(Tubi_Addy, 6, 0x89, 0x86, 0x3C, 0x22, 0x00, 0x00);
		WriteMemory(InstantDrop_Addy, 2, 0xDC, 0x0D);
		WriteMemory(NoLootAnimation_Addy, 6, 0x81, 0xFE, 0xBC, 0x02, 0x00, 0x00);
	}
}

void UnlimitedAttack(bool toggle)
{
	if (toggle)
	{
		WriteMemory(UnlimitedAttack_Addy, 1, 0xEB);
	}
	else
	{
		WriteMemory(UnlimitedAttack_Addy, 1, 0x7E);
	}
}

// Mob Hacks
void MobFreeze(bool toggle)
{
	if (toggle)
	{
		WriteMemory(MobFreeze_Addy, 2, 0x90, 0xE9);
	}
	else
	{
		WriteMemory(MobFreeze_Addy, 2, 0x0F, 0x85);
	}
}

void MobDisarm(bool toggle)
{
	if (toggle)
	{
		WriteMemory(MobDisarm_Addy, 9, 0xE9, 0x58, 0x04, 0x00, 0x00, 0x90, 0x90, 0x90, 0x90);
	}
	else
	{
		WriteMemory(MobDisarm_Addy, 9, 0x75, 0x15, 0x8B, 0xCE, 0xE8, 0xD3, 0x8E, 0xFE, 0xFF);
	}
}

DWORD MobItemVac_ReturnAddy = MobItemVac_Addy + 0x5;
__declspec(naked) void __stdcall MobItemVac_CC()
{
	__asm
	{
		push ecx
		mov ecx, dword ptr ds:[CharBase_Addy]
		mov edi, [ecx + CharX_Offset]
		mov eax, [ecx + CharY_Offset]
		pop ecx
		jmp dword ptr [MobItemVac_ReturnAddy]
	}
}

void MobItemVac(bool toggle)
{
	if (toggle) 
	{
		Jump(MobItemVac_Addy, MobItemVac_CC, 0);
	}
	else 
	{
		WriteMemory(MobItemVac_Addy, 5, 0xE8, 0xA7, 0x26, 0xAE, 0xFF);
	}
}

DWORD MobVac_ReturnAddy = MobVac_Addy + 0x6;
int MobVac_Type = -1;
__declspec(naked) void __stdcall MobVac_CC()
{
	__asm
	{
		push eax
		push ebx
		mov ebx, dword ptr ds : [TSingleton__CUserPool]
		mov ebx, [ebx + PeopleCount_Offset]
		mov eax, people_limit
		cmp ebx, eax
		jge mob_vac_check_skip
		mov eax, [MobVac_Type]
		mov [esi+0x1A0], eax
		mob_vac_check_skip:
		pop ebx
		pop eax
		jmp dword ptr [MobVac_ReturnAddy]
	}
}

int MobVacSupport_Check = 0;
int MobVacSupport_Delay = 0;
int MobVacSupport_Status = 0;
int MobVacSupport_PointX = 0;
int MobVacSupport_PointY = 0;
#define MobVacSupport_RetAddy 0x0132E65A;
DWORD MobVacSupportTele_CallAddy1 = 0x01402020;
DWORD MobVacSupportTele_CallAddy2 = 0x0148C3E0;
DWORD MobVacSupport_ReturnAddy = 0x01342C90;
__declspec(naked) void __stdcall MobVacSupport_CC()
{
	__asm
	{
		cmp dword ptr[esp], MobVacSupport_RetAddy
		pushad
		jne KamiExit
		mov eax, dword ptr ds : [CharBase_Addy]
		test eax, eax
		je KamiExit
		cmp [MobVacSupport_Check], 0
		je SaveCoords
		inc [MobVacSupport_Delay]
		cmp dword ptr[MobVacSupport_Delay], 0x12C // value 300
		jne KamiExit
		mov [MobVacSupport_Delay], 0
		cmp [MobVacSupport_Status], 0
		je TelePoint1
		jmp TelePoint2

		KamiExit :
		popad
		jmp dword ptr [MobVacSupport_ReturnAddy]

		NewTeleportXY :
		mov esi, dword ptr ds : [CharBase_Addy]
		lea ecx, [esi + 04]
		call dword ptr[MobVacSupportTele_CallAddy1]
		test eax, eax
		je TeleportEnd
		push ebx
		push edx
		push 00
		mov ecx, eax
		call dword ptr [MobVacSupportTele_CallAddy2]
		TeleportEnd:
		ret

		SaveCoords :
		mov [MobVacSupport_Check], 1
		push ebx
		push ecx
		mov ebx, dword ptr ds : [CharBase_Addy]
		mov ecx, [ebx + CharX_Offset]
		mov[MobVacSupport_PointX], ecx
		mov ecx, [ebx + CharY_Offset]
		mov[MobVacSupport_PointY], ecx
		pop ecx
		pop ebx
		jmp KamiExit

		TelePoint1 :
		mov [MobVacSupport_Status], 1
		mov ebx, [MobVacSupport_PointY]
		mov edx, [MobVacSupport_PointX]
		call NewTeleportXY
		jmp KamiExit

		TelePoint2 :
		mov[MobVacSupport_Status], 0
		mov ebx, [MobVacSupport_PointY]
		mov edx, [MobVacSupport_PointX]
		add edx, 0x64 // value 100
		call NewTeleportXY
		jmp KamiExit
	}
}

void MobVac(bool toggle) 
{
	MobVacSupport_Check = 0;
	MobVacSupport_Delay = 0;
	MobVacSupport_Status = 0;
	MobVacSupport_PointX = 0;
	MobVacSupport_PointY = 0;
	if (toggle)
	{
		Jump(MobVac_Addy, MobVac_CC, 1);
		*(unsigned long*)MobVacSupport_Addy = (unsigned long)MobVacSupport_CC;
		WriteMemory(FasterMobs_Addy, 2, 0x90, 0x90);
	}
	else
	{
		WriteMemory(MobVac_Addy, 6, 0xDD, 0x86, 0x20, 0x01, 0x00, 0x00);
		*(unsigned long*)MobVacSupport_Addy = (unsigned long)0x01342C90;
		WriteMemory(FasterMobs_Addy, 2, 0x75, 0x98);
	}
}

void MobVac_SetType(int option) 
{
	MobVac_Type = option;
}

// Misc. Hacks
DWORD SkillInjectionCC_JmpAddy1 = 0x013E1499;
DWORD SkillInjectionCC_JmpAddy2 = 0x013E1643;
int SkillInjection_DelayCounter = 0;
int SkillInjection_Speed = 1;
__declspec(naked) void __stdcall FullMapAttack_CC()
{
	__asm
	{
		push eax
		push ebx
		mov ebx, dword ptr ds : [TSingleton__CUserPool]
		mov ebx, [ebx + PeopleCount_Offset]
		mov eax, people_limit
		cmp ebx, eax
		jge skill_inject_check_skip
		mov eax, dword ptr ds : [TSingleton__CMobPool]
		mov eax, [eax + MobCount_Offset]
		mov ebx, mob_limit
		cmp ebx, eax
		jge skill_inject_check_skip
		inc[SkillInjection_DelayCounter]
		mov eax, dword ptr ds : [SkillInjection_Speed]
		cmp eax, dword ptr[SkillInjection_DelayCounter]
		jge skill_inject_check_skip
		mov[SkillInjection_DelayCounter], 0
		mov eax, 0x05A999A9
		mov[esi + 0x0000B93C], eax // 500k dmg skill in hex
		pop ebx
		pop eax
		jmp dword ptr[SkillInjectionCC_JmpAddy1]

		skill_inject_check_skip:
		pop ebx
		pop eax
		jmp dword ptr[SkillInjectionCC_JmpAddy2]
	}
}

__declspec(naked) void __stdcall BossAttack_CC()
{
	__asm
	{
		push eax
		push ebx
		mov ebx, dword ptr ds : [TSingleton__CUserPool]
		mov ebx, [ebx + PeopleCount_Offset]
		mov eax, people_limit
		cmp ebx, eax
		jge skill_inject_check_skip
		inc[SkillInjection_DelayCounter]
		cmp dword ptr[SkillInjection_DelayCounter], 25
		jne skill_inject_check_skip
		mov[SkillInjection_DelayCounter], 0
		mov eax, 0x04C4BA39
		mov[esi + 0x0000B93C], eax  // 50m dmg skill in hex
		pop ebx
		pop eax
		jmp dword ptr[SkillInjectionCC_JmpAddy1]

		skill_inject_check_skip:
		pop ebx
		pop eax
		jmp dword ptr[SkillInjectionCC_JmpAddy2]
	}
}

void SkillInjection(int option)
{
	SkillInjection_DelayCounter = 0;
	if (option == 1)
	{
		Jump(SkillInjection_Addy1, FullMapAttack_CC, 1);
		WriteMemory(SkillInjection_Addy2, 6, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
		WriteMemory(SkillInjection_Addy3, 7, 0xE9, 0x2F, 0x00, 0x00, 0x00, 0x90, 0x90);
		WriteMemory(SkillInjection_MobArray_Addy, 2, 0x90, 0x90);
		WriteMemory(GND_Addy, 1, 0x8A);
	}
	else if (option == 2)
	{
		Jump(SkillInjection_Addy1, BossAttack_CC, 1);
		WriteMemory(SkillInjection_Addy2, 6, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90);
		WriteMemory(SkillInjection_Addy3, 7, 0xE9, 0x2F, 0x00, 0x00, 0x00, 0x90, 0x90);
		WriteMemory(SkillInjection_NoMobKB_Addy, 2, 0x0F, 0x85);
		WriteMemory(SkillInjection_NoCharStuck_Addy, 2, 0x0F, 0x84);
		WriteMemory(GND_Addy, 1, 0x8A);
	}
	else
	{
		WriteMemory(SkillInjection_Addy1, 6, 0x0F, 0x84, 0xD6, 0x02, 0x00, 0x00);
		WriteMemory(SkillInjection_Addy2, 6, 0x0F, 0x87, 0xE1, 0x00, 0x00, 0x00);
		WriteMemory(SkillInjection_Addy3, 7, 0xFF, 0x24, 0x8D, 0x4C, 0x16, 0x3E, 0x01);
		WriteMemory(SkillInjection_MobArray_Addy, 2, 0x75, 0x2B);
		WriteMemory(SkillInjection_NoMobKB_Addy, 2, 0x0F, 0x84);
		WriteMemory(SkillInjection_NoCharStuck_Addy, 2, 0x0F, 0x85);
		WriteMemory(GND_Addy, 1, 0x8B);
	}
}

void SkillInjection_SetSpeed(int option)
{
	SkillInjection_DelayCounter = 0;
	SkillInjection_Speed = option;
}