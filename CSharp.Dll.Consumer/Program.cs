using System;

namespace CSharp.Dll.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCase_0();
            TestCase_1();
            //TestCase_2();
            //TestCase_3();
        }

        static void TestCase_0()
        {
            Console.WriteLine(DllConsumer.Sum(3, 2));
            Console.WriteLine(DllConsumer.SayHelloWorld());

            Console.ReadLine();
        }

        /// <summary>
        /// Allocate and free unmanaged memory.
        /// </summary>
        static void TestCase_1()
        {
            var consumer = new DllConsumer();

            Console.ReadLine();

            // see how process memory jumps up for 10 Mb
            consumer.Allocate(1024 * 1024 * 10);
            Console.WriteLine("Allocate: memory usage increased up for 10 Mb.");

            Console.ReadLine();

            // than it comes back 
            consumer.Free();
            Console.WriteLine("And now free it.");

            Console.ReadLine();

            consumer.IncrementCouter();
            Console.WriteLine($"Counter value: {consumer.GetCounter()}");
            Console.WriteLine("We free memory but don't destroy pointer.");

            Console.ReadLine();
        }

        /// <summary>
        /// Check that unmanaged object keeps its state.
        /// </summary>
        static void TestCase_2()
        {
            var consumer = new DllConsumer();
            Console.WriteLine(consumer.GetCounter());
            consumer.IncrementCouter();
            Console.WriteLine(consumer.GetCounter());
            consumer.IncrementCouter();
            Console.WriteLine(consumer.GetCounter());

            Console.ReadLine();
        }

        static void TestCase_3()
        {
            var consumer = new DllConsumer();

            Console.ReadLine();

            // see how process memory jumps up for 10 Mb
            consumer.Allocate(1024 * 1024 * 10);
            consumer.Allocate(1024 * 1024 * 10);
            consumer.Allocate(1024 * 1024 * 10);

            Console.WriteLine("Allocate: memory usage increased up for 10 Mb.");

            Console.ReadLine();

            consumer.Free();
            GC.Collect();

            Console.ReadLine();
        }
    }
}
