using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace DotNetCoreApiSample.Api.Middleware.MyContext
{
    /// <summary>
    /// MyContextMiddlewareです。
    /// </summary>
    public class MyContextMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="next">next</param>
        public MyContextMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// ミドルウェアの処理を実行します。
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="contextAccessor">contextAccessor</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IMyContextAccessor contextAccessor)
        {
            contextAccessor.Context = new MyContextModel
            {
                RequestId = context.TraceIdentifier,
                UserAgent = context.Request.Headers[HeaderNames.UserAgent]
            };
            await next(context);
        }
    }
}
