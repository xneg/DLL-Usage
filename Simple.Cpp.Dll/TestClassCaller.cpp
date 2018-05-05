#include <stdlib.h> 

#include "Header.h"
#include "TestClass.h"

extern "C"
{
	DLLEXPORT TestClass* CreateTestClass()
	{
		return new TestClass();
	}

	DLLEXPORT void Allocate(TestClass* p_testClass, int size)
	{
		if (p_testClass != NULL)
		{
			p_testClass->Allocate(size);
		}
	}

	DLLEXPORT void Deallocate(TestClass* p_testClass)
	{
		if (p_testClass != NULL)
		{
			p_testClass->Free();
		}
	}

	DLLEXPORT void Free(TestClass* p_testClass)
	{
		if (p_testClass != NULL)
		{
			delete p_testClass;
		}
	}

	DLLEXPORT void IncrementCounter(TestClass* p_testClass)
	{
		if (p_testClass != NULL)
		{
			p_testClass->IncrementCounter();
		}
	}

	DLLEXPORT int GetCounter(TestClass* p_testClass)
	{
		if (p_testClass != NULL)
		{
			return p_testClass->GetCounter();
		}
	}
}