using System;

namespace CSharp.Dll.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DllConsumer.Sum(3, 2));
            Console.WriteLine(DllConsumer.SayHello());
            Console.ReadLine();
        }
    }
}
