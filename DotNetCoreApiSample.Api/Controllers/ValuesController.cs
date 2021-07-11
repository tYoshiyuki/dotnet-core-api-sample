using System;
using System.Net;
using DotNetCoreApiSample.Api.Middleware;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace DotNetCoreApiSample.Api.Controllers
{
    /// <summary>
    /// ValuesController です。
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyContext myContext;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="contextAccessor"></param>
        public ValuesController(IMyContextAccessor contextAccessor)
        {
            this.myContext = contextAccessor.Context;
        }

        /// <summary>
        /// サンプルデータを取得します。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ValuesResponse))]
        public ValuesResponse Get()
        {
            return new()
            {
                UserAgent = myContext.UserAgent,
                RequestId = myContext.RequestId,
                Value = new Random().Next(0, 10).ToString()
            };
        }
    }
}
