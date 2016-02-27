#ifndef PIPESERVERSTRUCT_H
#define PIPESERVERSTRUCT_H

#include "Definitions.h"

typedef struct
{
	DWORD ControlCode;
	LPVOID Data;
} PIPE_MESSAGE, *PPIPE_MESSAGE;

#endif // PIPESERVERSTRUCT_H
