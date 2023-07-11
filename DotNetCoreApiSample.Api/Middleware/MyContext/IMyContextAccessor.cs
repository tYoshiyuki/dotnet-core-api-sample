namespace DotNetCoreApiSample.Api.Middleware.MyContext
{
    /// <summary>
    /// MyContextAccessorインターフェースです。
    /// </summary>
    public interface IMyContextAccessor
    {
        /// <summary>
        /// MyContextです。
        /// </summary>
        MyContextModel Context { get; set; }
    }
}
