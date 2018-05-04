#pragma once
#include "Header.h"

DLLEXPORT class TestClass
{
public:
	TestClass();
	virtual ~TestClass();

	void Allocate(int count);
	void Free();

	void IncrementCounter();
	int GetCounter();
};

