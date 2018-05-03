#pragma once
#define DLLEXPORT __declspec(dllexport)

extern "C"
{
	DLLEXPORT const char* ReturnCharPtr();

	DLLEXPORT int Add(int a, int b);
}