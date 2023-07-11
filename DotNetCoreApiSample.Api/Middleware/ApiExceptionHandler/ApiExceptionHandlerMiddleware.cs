using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Diagnostics;

namespace DotNetCoreApiSample.Api.Middleware.ApiExceptionHandler
{
    /// <summary>
    /// <see cref="ApiExceptionHandlerMiddleware"/> です。
    /// </summary>
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="next"></param>
        public ApiExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// ミドルウェアの処理を実行します。
        /// </summary>
        /// <param name="context">context</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature == null)
            {
                await next(context);
                return;
            }

            var ex = exceptionHandlerFeature.Error;
            await HandleExceptionAsync(context, ex);
        }

        /// <summary>
        /// 例外処理を実行します。
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="exception">exception</param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Internal Server Error from the custom middleware.",
                detail = exception.Message,
                stackTrace = exception.StackTrace
            });
        }
    }
}
