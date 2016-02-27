#ifndef ASYNC_OSTREAM_H
#define ASYNC_OSTREAM_H

#include <iostream>
#include <sstream>
#include <Windows.h>
using namespace std;

class async_ostream
{
	public:
		~async_ostream();

		template <typename T>
		async_ostream &operator<<(T const &value)
		{
			EnterCriticalSection(&m_CriticalSection);
			buffer_ << value;
			LeaveCriticalSection(&m_CriticalSection);
			return *this;
		}

		static void init();
		static void cleanup();

	private:
		ostringstream buffer_;
		static CRITICAL_SECTION m_CriticalSection;
};

#endif // ASYNC_OSTREAM_H