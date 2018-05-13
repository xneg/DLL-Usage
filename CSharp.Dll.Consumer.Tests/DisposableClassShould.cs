using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSharp.Dll.Consumer.Tests
{
    public class DisposableClassShould
    {
        private const int MemorySize = 1024 * 1024 * 10;

        private readonly ITestOutputHelper output;

        public DisposableClassShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void FreeMemoryWhenUsing()
        {
            var allMemoryBeforeAllocation = Process.GetCurrentProcess().PrivateMemorySize64;

            using (var disposableClass = new DisposableClass())
            {
                disposableClass.AllocateMemory(MemorySize);
                var allMemoryAfterAllocation = Process.GetCurrentProcess().PrivateMemorySize64;

                Assert.True(allMemoryAfterAllocation - allMemoryBeforeAllocation >= MemorySize,
                    "size of total used memory increased");
            }
            var allMemoryAfterFree = Process.GetCurrentProcess().PrivateMemorySize64;

            Assert.True(allMemoryAfterFree - allMemoryBeforeAllocation <= MemorySize / 10,
                    "size of total used memory decreased");
        }

        [Fact]
        public void FreeMemoryWithFinalizer()
        {
            AllocateDisposableClass();
            var allMemoryAfterAllocation = Process.GetCurrentProcess().PrivateMemorySize64;

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            var allMemoryAfterFree = Process.GetCurrentProcess().PrivateMemorySize64;

            Assert.True(allMemoryAfterAllocation - allMemoryAfterFree >= MemorySize,
                    "size of total used memory decreased");
        }

        [Fact]
        public void ThrowObjectDisposedExceptionAfterDisposing()
        {
            var disposableClass = new DisposableClass();

            disposableClass.Dispose();

            Assert.Throws<ObjectDisposedException>(() => disposableClass.AllocateMemory(MemorySize));
        }

        static void AllocateDisposableClass()
        {
            new DisposableClass().AllocateMemory(MemorySize);
        }
    }
}
