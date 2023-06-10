using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace DotNetCoreApiSample.Api
{
    /// <summary>
    /// クエリパラメータをキャメルケースに変換するための <see cref="IApiDescriptionProvider"/>
    /// </summary>
    public class CamelCaseQueryParametersApiDescriptionProvider : IApiDescriptionProvider
    {
        /// <inheritdoc />
        public int Order => 1;

        /// <inheritdoc />
        public void OnProvidersExecuted(ApiDescriptionProviderContext context) { }

        /// <inheritdoc />
        public void OnProvidersExecuting(ApiDescriptionProviderContext context)
        {
            foreach (var parameter in context.Results.SelectMany(x => x.ParameterDescriptions)
                         .Where(x => x.Source.Id == "Query"))
            {
                if (parameter.Name.Length > 0)
                {
                    parameter.Name = char.ToLower(parameter.Name[0]) + parameter.Name[1..];
                }
            }
        }
    }
}
