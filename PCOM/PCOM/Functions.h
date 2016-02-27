#ifndef FUNCTIONS_H
#define FUNCTIONS_H

#include "Definitions.h"
#endif // FUNCTIONS_H

void WriteMemory(unsigned long ulAddress, unsigned char ucAmount, ...);
bool Jump(unsigned long ulAddress, void* Function, unsigned long ulNops);
unsigned long ReadPointer(unsigned long ulBase, int iOffset);