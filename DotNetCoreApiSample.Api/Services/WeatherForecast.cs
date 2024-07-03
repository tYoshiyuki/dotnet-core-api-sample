using System;

namespace DotNetCoreApiSample.Api.Services
{
    /// <summary>
    /// WeatherForecast
    /// </summary>
    /// <example>
    /// {
    ///   "date": "2021-07-12T11:15:39.7968638+09:00",
    ///   "temperatureC": 49,
    ///   "temperatureF": 120,
    ///   "summary": "Chilly"
    /// }
    /// </example>
    public class WeatherForecast
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// TemperatureC
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// TemperatureF
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }
    }
}
