using Microsoft.AspNetCore.Builder;

namespace DotNetCoreApiSample.Api.Middleware.MyContext
{
    /// <summary>
    /// MyContextMiddlewareExtensionsです。
    /// </summary>
    public static class MyContextMiddlewareExtensions
    {
        /// <summary>
        /// MyContextMiddlewareを適用します。
        /// </summary>
        /// <param name="builder">builder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseMyContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyContextMiddleware>();
        }
    }
}
