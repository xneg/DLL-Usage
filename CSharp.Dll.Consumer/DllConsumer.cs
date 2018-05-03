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

        public static int Sum(int a, int b)
        {
            return Add(a, b);
        }

        public static string SayHello()
        {
            return Marshal.PtrToStringAnsi(ReturnCharPtr());
        }
    }
}
