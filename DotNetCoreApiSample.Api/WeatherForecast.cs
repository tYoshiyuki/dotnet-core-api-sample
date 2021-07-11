using System;

namespace DotNetCoreApiSample.Api
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
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
