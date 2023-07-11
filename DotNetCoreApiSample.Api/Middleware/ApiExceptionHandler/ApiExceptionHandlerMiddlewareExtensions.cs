using Microsoft.AspNetCore.Builder;

namespace DotNetCoreApiSample.Api.Middleware.ApiExceptionHandler
{
    /// <summary>
    /// ApiExceptionHandlerMiddlewareExtensionsです。
    /// </summary>
    public static class ApiExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// ApiExceptionHandlerMiddlewareを適用します。
        /// </summary>
        /// <param name="builder">builder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionHandlerMiddleware>();
        }
    }
}
