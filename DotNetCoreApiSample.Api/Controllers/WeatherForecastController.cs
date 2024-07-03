using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NSwag.Annotations;
using DotNetCoreApiSample.Api.Services;

namespace DotNetCoreApiSample.Api.Controllers
{
    /// <summary>
    /// WeatherForecastController です。
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="logger"></param>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private static readonly string[] summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> logger = logger;

        /// <summary>
        /// WeatherForecast を取得します。
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<WeatherForecast>))]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            logger.LogInformation(rng.ToString());

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            })
            .ToArray();
        }
    }
}
