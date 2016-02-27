#include "async_ostream.h"

CRITICAL_SECTION async_ostream::m_CriticalSection;

void async_ostream::init()
{
	InitializeCriticalSection(&m_CriticalSection);
}

void async_ostream::cleanup()
{
	DeleteCriticalSection(&m_CriticalSection);
}

async_ostream::~async_ostream()
{
	cout << buffer_.str();
}
