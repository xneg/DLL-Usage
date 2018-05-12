using System;
using System.Diagnostics;

namespace CSharp.Dll.Consumer
{
    class Program
    {
        private const int MemorySize = 1024 * 1024 * 10;

        static void Main(string[] args)
        {
            //TestCase_3();
            //TestCase_4();
            //DisposableCase_1();
            //DisposableCase_2();
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

            Console.ReadLine();
        }

        /// <summary>
        /// Properly use (with using).
        /// </summary>
        static void DisposableCase_1()
        {
            using (var disposableClass = new DisposableClass())
            {
                Console.ReadLine();
                disposableClass.AllocateMemory(MemorySize);
                Console.ReadLine();
            }
            Console.WriteLine("Dispose called");
            Console.ReadLine();
        }

        /// <summary>
        /// Using GC to call Finalizer
        /// </summary>
        static void DisposableCase_2()
        {
            Console.ReadLine();

            AllocateDisposableClass();

            Console.ReadLine();
            Console.WriteLine("GC Collect");
            GC.Collect(2, GCCollectionMode.Forced);
            Console.ReadLine();
        }

        static void AllocateDisposableClass()
        {
            new DisposableClass().AllocateMemory(MemorySize);
        }
    }
}
