using System;
using System.Runtime.InteropServices;

namespace CSharp.Dll.Consumer
{
    internal static class NativeMethods
    {
        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateTestClass();

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Allocate(IntPtr pTestClass, int count);

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Deallocate(IntPtr pTestClass);

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Free(IntPtr pTestClass);
    }
}
