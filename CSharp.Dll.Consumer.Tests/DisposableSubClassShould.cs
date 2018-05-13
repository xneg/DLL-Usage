using Moq;
using System;
using Xunit;

namespace CSharp.Dll.Consumer.Tests
{
    public class DisposableSubClassShould
    {
        [Fact]
        public void CallDisposeFromDisposableDependency()
        {
            var dependencyMock = new Mock<IDisposable>();
            using (var disposableSubClass = new DisposableSubClass(dependencyMock.Object))
            {
            }
            dependencyMock.Verify(dependency => dependency.Dispose(), Times.Once);
        }

        [Fact]
        public void ActLikeBaseClass()
        {
            var dependencyMock = new Mock<IDisposable>();
            DisposableClass disposableClass;
            disposableClass = new DisposableSubClass(dependencyMock.Object);
            disposableClass.Dispose();

            dependencyMock.Verify(dependency => dependency.Dispose(), Times.Once);

        }
    }
}
