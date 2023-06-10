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
        public ValuesResponse Get([FromQuery] ValuesRequest request)
        {
            return new()
            {
                UserAgent = myContext.UserAgent,
                RequestId = myContext.RequestId,
                Value = request.SampleValue
            };
        }


        /// <summary>
        /// サンプルデータを取得します。
        /// </summary>
        /// <param name="request"><see cref="ValuesRequest"/></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(ValuesResponse))]
        public ValuesResponse Post([FromBody] ValuesRequest request)
        {
            return new()
            {
                UserAgent = myContext.UserAgent,
                RequestId = myContext.RequestId,
                Value = request.SampleValue
            };
        }

        /// <summary>
        /// サンプルのため例外を発生させます。
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("Exception")]
        [HttpGet]
        public IActionResult Exception()
        {
            throw new Exception("This is sample error!");
        }


    }
}
