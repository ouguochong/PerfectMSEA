#include "Bots.h"

bool AutoLootToggle = false;
void AutoLootThread() {
	while (AutoLootToggle) {
		SendKey(VK_NUMPAD0);
		Sleep(35);
	}
}

void AutoLoot(bool toggle)
{
	if (toggle)
	{
		AutoLootToggle = true;
		NewThread(AutoLootThread);
	}
	else
	{
		AutoLootToggle = false;
	}
}