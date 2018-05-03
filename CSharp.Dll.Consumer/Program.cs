using System;

namespace CSharp.Dll.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DllConsumer.Sum(3, 2));
            Console.WriteLine(DllConsumer.SayHello());

            var consumer = new DllConsumer();

            Console.ReadLine();

            // see how process memory jumps up for 10 Mb
            consumer.Allocate(1024 * 1024 * 10);

            Console.ReadLine();

            // todo: but not back... =(
            consumer.Free();
            GC.Collect();

            Console.ReadLine();
        }
    }
}
