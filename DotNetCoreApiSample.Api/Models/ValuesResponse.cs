namespace DotNetCoreApiSample.Api.Models
{
    /// <summary>
    /// ValuesResponse
    /// </summary>
    /// <example>
    /// {
    ///   "requestId": "80000004-0001-fd00-b63f-84710c7967bb",
    ///   "userAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
    ///   "value": "5"
    /// }
    /// </example>
    public class ValuesResponse
    {
        /// <summary>
        /// RequestId
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
