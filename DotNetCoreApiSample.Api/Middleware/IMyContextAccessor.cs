namespace DotNetCoreApiSample.Api.Middleware
{
    /// <summary>
    /// MyContextAccessorインターフェースです。
    /// </summary>
    public interface IMyContextAccessor
    {
        /// <summary>
        /// MyContextです。
        /// </summary>
        MyContext Context { get; set; }
    }
}
