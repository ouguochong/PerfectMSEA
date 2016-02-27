#ifndef HACKS_H
#define HACKS_H

#include "Definitions.h"

#endif // HACKS_H

// Information
int GetPeopleCount();
int GetMobCount();

// CPU Hacks
void NoBackground(bool toggle);
void NoDamageText(bool toggle);

// Char Hacks
void StanceHack(bool toggle);
void ItemFilter(bool toggle);
void PerfectLoot(bool toggle);
void UnlimitedAttack(bool toggle);

// Mob Hacks
void MobFreeze(bool toggle);
void MobDisarm(bool toggle);
void MobItemVac(bool toggle);
void MobVac(bool toggle);
void MobVac_SetType(int options);

// Misc. Hacks
void SkillInjection(int option);
void SkillInjection_SetSpeed(int option);