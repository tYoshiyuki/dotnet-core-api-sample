using System.Threading.Tasks;
using DotNetCoreApiSample.Api.Middleware.MyContext;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace DotNetCoreApiSample.Api.Test.Middleware
{
    /// <summary>
    /// <see cref="MyContextMiddleware"/> のテストクラスです。
    /// </summary>
    [TestFixture]
    public class MyContextMiddlewareTest
    {
        /// <summary>
        /// <see cref="MyContextMiddleware.Invoke"/> が正常に動作する事を確認します。
        /// </summary>
        /// <returns></returns>
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
