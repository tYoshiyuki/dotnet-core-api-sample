namespace DotNetCoreApiSample.Api.Middleware.MyContext
{
    /// <summary>
    /// MyContextAccessorです。
    /// </summary>
    public class MyContextAccessor : IMyContextAccessor
    {
        private MyContextModel contextHolder;

        /// <summary>
        /// <see cref="MyContextModel"/> です。
        /// </summary>
        public MyContextModel Context
        {
            get => contextHolder;
            set => contextHolder ??= value;
        }
    }
}
