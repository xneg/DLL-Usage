using System;

namespace CSharp.Dll.Consumer
{
    class Program
    {
        private const int MemorySize = 1024 * 1024 * 10;

        static void Main(string[] args)
        {
            //TestCase_3();
            TestCase_4();
        }

        static void TestCase_3()
        {
            var consumer = new DllConsumer();

            Console.ReadLine();

            // see how process memory jumps up for 10 Mb
            consumer.Allocate(MemorySize);
            consumer.Allocate(MemorySize);
            consumer.Allocate(MemorySize);

            Console.WriteLine("Allocate: memory usage increased up for 10 Mb.");

            Console.ReadLine();

            consumer.Deallocate();
            GC.Collect();

            Console.ReadLine();
        }

        /// <summary>
        /// Try to finally destroy unmanaged object.
        /// </summary>
        static void TestCase_4()
        {
            var consumer = new DllConsumer();

            consumer.Allocate(MemorySize);
            Console.ReadLine();

            consumer.Deallocate();

            // here we destroy unmanaged object (but it's not exactly)
            consumer.Free();

            consumer.IncrementCouter();
            Console.WriteLine(consumer.GetCounter());

            //double f = 1024.0;
            //Process[] localByName = Process.GetProcessesByName("360Safe");
            //foreach (Process p in localByName)
            //{
            //    Console.WriteLine("Private memory size64: {0}", (p.PrivateMemorySize64 / f).ToString("#,##0"));
            //    Console.WriteLine("Working Set size64: {0}", (p.WorkingSet64 / f).ToString("#,##0"));
            //    Console.WriteLine("Peak virtual memory size64: {0}", (p.PeakVirtualMemorySize64 / f).ToString("#,##0"));
            //    Console.WriteLine("Peak paged memory size64: {0}", (p.PeakPagedMemorySize64 / f).ToString("#,##0"));
            //    Console.WriteLine("Paged system memory size64: {0}", (p.PagedSystemMemorySize64 / f).ToString("#,##0"));
            //    Console.WriteLine("Paged memory size64: {0}", (p.PagedMemorySize64 / f).ToString("#,##0"));
            //    Console.WriteLine("Nonpaged system memory size64: {0}", (p.NonpagedSystemMemorySize64 / f).ToString("#,##0"));
            //}

            Console.ReadLine();
        }
    }
}
