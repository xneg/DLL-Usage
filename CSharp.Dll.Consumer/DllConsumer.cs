using System;
using System.Runtime.InteropServices;

namespace CSharp.Dll.Consumer
{
    public class DllConsumer
    {
        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Add(int a, int b);

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr ReturnCharPtr();

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateTestClass();

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Allocate(IntPtr pTestClass, int count);

        [DllImport("Simple.Cpp.Dll.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Free(IntPtr pTestClass);

        public static int Sum(int a, int b)
        {
            return Add(a, b);
        }

        public static string SayHello()
        {
            return Marshal.PtrToStringAnsi(ReturnCharPtr());
        }

        private IntPtr _testClass;

        public DllConsumer()
        {
            _testClass = CreateTestClass();
        }

        public void Allocate(int size)
        {
            Allocate(_testClass, size);
        }

        public void Free()
        {
            Free(_testClass);
        }
    }
}
