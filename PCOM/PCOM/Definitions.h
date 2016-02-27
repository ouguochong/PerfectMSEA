
#ifndef DEFINITIONS_H
#define DEFINITIONS_H

#include <Windows.h>
#include <iostream>
#include <sstream>
#include <vector>
#include <assert.h>

#include "PCOM.h"
#include "async_ostream.h"
#include "PipeServer.h"
#include "PipeServerStruct.h"

#include "Functions.h"
#include "Bots.h"
#include "Hacks.h"

using namespace std;

// Important definitions
#define endl "\n" // pipe server
#define async_cout async_ostream() // pipe server
#define jmp(frm, to) (int)(((int)to - (int)frm) - 5)
#define SendKey(Key) PostMessage(FindWindow(L"MapleStoryClass", 0), WM_KEYDOWN, Key, (MapVirtualKey(Key, 0) << 16) + 1)
#define NewThread(Function) CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)&Function, NULL, 0, NULL)

/// Hacks
// Information: 0x01 -> 0x19
#define PEOPLE_COUNT 0x01
#define MOB_COUNT 0x02

// Bots: 0x50 -> 0x99
#define AUTO_LOOT 0x50

// CPU Hacks: 0x100 -> 0x199
#define NO_BACKGROUND 0x100
#define NO_DAMAGE_TEXT 0x110

// Char Hacks: 0x200 -> 0x299
#define STANCE_HACK 0x200
#define ITEM_FILTER 0x210
#define PERFECT_LOOT 0x220
#define UNLIMITED_ATTACK 0x230

// Mob Hacks: 0x300 -> 0x399
#define MOB_FREEZE 0x300
#define MOB_DISARM 0x310
#define MOB_ITEM_VAC 0x320
#define MOB_VAC 0x330
#define MOB_VAC_TYPE 0x331

// Misc. Hacks: 0x400 -> 499
#define SKILL_INJECTION 0x400
#define SKILL_INJECTION_SPEED 0x401

// Limiters
#define people_limit 1
#define mob_limit 1

// ADDIES
#define ThemidaCRC_Addy 0x01538300
#define LogoSkipper_Addy 0x009592F9

#define TSingleton__CUserPool 0x01BB0CA8
#define PeopleCount_Offset 0x18
#define TSingleton__CMobPool 0x01BB0CAC
#define MobCount_Offset 0x10

#define CharBase_Addy 0x01BAC708
#define CharX_Offset 0xCC14
#define CharY_Offset CharX_Offset + 0x04

#define NoBackground_Addy 0x00976CF7
#define NoDamageText_Addy 0x009EAB50

#define StanceHack_Addy 0x00C4C78A
#define ItemFilter_Addy 0x006A8E39
#define Tubi_Addy 0x014E6AF7
#define InstantDrop_Addy 0x0069F464
#define NoLootAnimation_Addy 0x004D0AC9
#define UnlimitedAttack_Addy 0x0132D8B0

#define MobFreeze_Addy 0x00A06136
#define MobDisarm_Addy 0x00A05394
#define MobItemVac_Addy 0x009B1064
#define MobVac_Addy 0x01499E90
#define MobVacSupport_Addy 0x019D2C4C
#define FasterMobs_Addy 0x00A3F346

#define SkillInjection_Addy1 0x013E1367
#define SkillInjection_Addy2 0x013E1554
#define SkillInjection_Addy3 0x013E1561
#define SkillInjection_MobArray_Addy 0x00A07BEE
#define SkillInjection_NoMobKB_Addy 0x013C34C4
#define SkillInjection_NoCharStuck_Addy 0x00A0237D
#define GND_Addy 0x0137FAE0

#endif // DEFINITIONS_H