using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSharp.Dll.Consumer.Tests
{
    public class DllConsumerShould
    {
        private const int MemorySize = 1024 * 1024 * 10;

        private readonly ITestOutputHelper output;

        public DllConsumerShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void SumTwoNumbers()
        {
            var result = DllConsumer.Sum(3, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void SayHelloWorld()
        {
            var result = DllConsumer.SayHelloWorld();
            Assert.Equal("Hello world!", result);
        }

        [Fact]
        public void KeepItsState()
        {
            var consumer = new DllConsumer();
            Assert.Equal(0, consumer.GetCounter());

            consumer.IncrementCouter();
            Assert.Equal(1, consumer.GetCounter());

            consumer.IncrementCouter();
            Assert.Equal(2, consumer.GetCounter());
        }

        [Fact]
        public void AllocateMemory()
        {
            var consumer = new DllConsumer();

            var allMemoryBeforeAllocation = Process.GetCurrentProcess().PrivateMemorySize64;
            var managedMemoryBeforeAllocation = GC.GetTotalMemory(false);

            consumer.Allocate(MemorySize);

            var managedMemoryAfterAllocation = GC.GetTotalMemory(false);

            var allMemoryAfterAllocation = Process.GetCurrentProcess().PrivateMemorySize64;

            Assert.True(allMemoryAfterAllocation - allMemoryBeforeAllocation >= MemorySize,
                "size of total used memory increased");

            // size of managed used memory doesn't change
            Assert.Equal(managedMemoryBeforeAllocation, managedMemoryAfterAllocation);

            consumer.Deallocate();
        }

        [Fact]
        public void FreeMemory()
        {
            GC.TryStartNoGCRegion(MemorySize * 2, true);

            var consumer = new DllConsumer();

            consumer.Allocate(MemorySize);

            var allMemoryAfterAllocation = Process.GetCurrentProcess().PrivateMemorySize64;
            var managedMemoryAfterAllocation = GC.GetTotalMemory(false);

            consumer.Deallocate();

            var managedMemoryAfterFree = GC.GetTotalMemory(false);
            var allMemoryAfterFree = Process.GetCurrentProcess().PrivateMemorySize64;

            GC.EndNoGCRegion();

            Assert.True(allMemoryAfterAllocation - managedMemoryAfterFree >= MemorySize,
                "size of total used memory decresead");

            // size of managed used memory doesn't change
            Assert.Equal(managedMemoryAfterAllocation, managedMemoryAfterAllocation);
        }
    }
}
