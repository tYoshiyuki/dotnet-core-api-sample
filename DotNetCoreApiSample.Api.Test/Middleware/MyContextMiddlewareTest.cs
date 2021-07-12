using System.Threading.Tasks;
using DotNetCoreApiSample.Api.Middleware;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace DotNetCoreApiSample.Api.Test.Middleware
{
    [TestFixture]
    public class MyContextMiddlewareTest
    {
        [Test]
        public async Task Invoke_正常系()
        {
            // Arrange
            var middleware = new MyContextMiddleware(x => Task.FromResult(0));
            var httpContext = new DefaultHttpContext();
            var accessor = new MyContextAccessor();

            // Act
            await middleware.Invoke(httpContext, accessor);

            // Assert
            Assert.That(accessor.Context, Is.Not.Null);
        }
    }
}
