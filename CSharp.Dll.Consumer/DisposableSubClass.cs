using System;

namespace CSharp.Dll.Consumer
{
    public sealed class DisposableSubClass : DisposableClass
    {
        private bool _disposed;
        private IDisposable _disposableDependency;

        public DisposableSubClass(IDisposable disposableDependency)
            : base()
        {
            _disposableDependency = disposableDependency;
        }

        public void DoSomeWork()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(DisposableSubClass));
            }
            // Do some work...
        }

        protected override void Dispose(bool disposing)
        {
            // Only do something if we're not already disposed
            if (!_disposed)
            {
                // If disposing == true, we're being called from a call to base.Dispose(). 
                // Here we dispose managed resources.
                if (disposing)
                {
                    _disposableDependency.Dispose();
                }
                // Flag us as disposed.  This allows us to handle multiple calls to Dispose() as well as ObjectDisposedException
               _disposed = true;
            }
            // This should always be safe to call multiple times!  
            // We could include it in the check for this.disposed above, but I left it out to demonstrate that it's safe
            base.Dispose(disposing);
        }
    }
}
