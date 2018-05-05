#include <stdlib.h> 
#include <iostream>

#include "TestClass.h"

char* x;
int counter = 0;

TestClass::TestClass()
{
	printf("C++ : TestClass created\n");
}

TestClass::~TestClass()
{
	printf("C++ : TestClass destroyed\n");
}

void TestClass::Allocate(int size)
{
	x = (char*)malloc(size);
	printf("C++ : Allocate memory\n");
}

void TestClass::Free()
{
	free(x);
	printf("C++ : Free memory\n");
}

void TestClass::IncrementCounter()
{
	counter++;
}

int TestClass::GetCounter()
{
	return counter;
}
