#include <stdlib.h> 

#include "Header.h"
#include "TestClass.h"

extern "C"
{
	DLLEXPORT TestClass* CreateSomeClass()
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

	DLLEXPORT void Free(TestClass* p_testClass)
	{
		if (p_testClass != NULL)
		{
			p_testClass->Free();
			delete(p_testClass);
		}
	}
}