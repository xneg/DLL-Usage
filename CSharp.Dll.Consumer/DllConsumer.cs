using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharp.Dll.Consumer
{
    public class DllConsumer
    {
        [DllImport("SimpleDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int AddNumsReturn(int a, int b);
    }
}
