#ifndef PCOM_H
#define PCOM_H

#include "Definitions.h"
#endif // PCOM_H

namespace PCOM 
{
	BOOL Initialization();
	void Error(char message[], BOOL kill);
}