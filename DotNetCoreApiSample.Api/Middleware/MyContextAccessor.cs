namespace DotNetCoreApiSample.Api.Middleware
{
    /// <summary>
    /// MyContextAccessorです。
    /// </summary>
    public class MyContextAccessor : IMyContextAccessor
    {
        private MyContext contextHolder;

        /// <summary>
        /// MyContextです。
        /// </summary>
        public MyContext Context
        {
            get => contextHolder;
            set => contextHolder ??= value;
        }
    }
}
