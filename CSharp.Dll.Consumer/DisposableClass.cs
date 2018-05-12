using System;

namespace CSharp.Dll.Consumer
{
    /// <summary>
    /// See this http://reedcopsey.com/2009/03/28/idisposable-part-1-releasing-unmanaged-resources/
    /// </summary>
    public class DisposableClass : IDisposable
    {
        private bool _disposed;
        private IntPtr _testClass;

        public DisposableClass()
        {
            _testClass = NativeMethods.CreateTestClass();
        }

        /// <summary>
        /// Any class with native resources should contain a finalizer.
        /// </summary>
        ~DisposableClass()
        {
            Console.WriteLine("Disposable class finalizer called.");
            Dispose(false);
        }

        public void AllocateMemory(int size)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(DisposableClass));
            }

            NativeMethods.Allocate(_testClass, size);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // If we have any managed, IDisposable resources, Dispose of them here.
                    // In this case, we don't, so this was unneeded.
                    // Later, we will subclass this class, and use this section.
                }

                // Always dispose of undisposed unmanaged resources in Dispose(bool)
                NativeMethods.Deallocate(_testClass);
                _testClass = IntPtr.Zero;
            }
            // Mark us as disposed, to prevent multiple calls to dispose from having an effect, 
            // and to allow us to handle ObjectDisposedException
            _disposed = true;
        }

        public void Dispose()
        {
            Console.WriteLine("Disposable class dispose called.");
            // We start by calling Dispose(bool) with true
            Dispose(true);
            // Now suppress finalization for this object, since we've already handled our resource cleanup tasks
            GC.SuppressFinalize(this);
        }
    }
}
