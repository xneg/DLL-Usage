#include <stdlib.h> 

#include "TestClass.h"

char* x;

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
}
