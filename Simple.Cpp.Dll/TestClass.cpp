#include <stdlib.h> 

#include "TestClass.h"

char* x;
int counter = 0;

TestClass::TestClass()
{
}

TestClass::~TestClass()
{
}

void TestClass::Allocate(int size)
{
	x = (char*)malloc(size);
}

void TestClass::Free()
{
	free(x);
}

void TestClass::IncrementCounter()
{
	counter++;
}

int TestClass::GetCounter()
{
	return counter;
}
