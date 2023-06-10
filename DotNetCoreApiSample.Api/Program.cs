using System.Linq;
using DotNetCoreApiSample.Api;
using DotNetCoreApiSample.Api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.ConfigureServices(services =>
{
    services.AddScoped<IMyContextAccessor, MyContextAccessor>();
    services.AddControllers();
    services.AddOpenApiDocument(document =>
    {
        document.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT",
            Description = "Type into the textbox: {your JWT token}."
        });

        document.OperationProcessors.Add(
            new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
    });
    services.TryAddEnumerable(ServiceDescriptor.Transient<IApiDescriptionProvider, CamelCaseQueryParametersApiDescriptionProvider>());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi3(config =>
    {
        config.Path = "/swagger";
    });
    app.UseReDoc(config =>
    {
        config.Path = "/redoc";
    });
}

app.UseExceptionHandler(configure =>
{
    configure.UseApiExceptionHandler();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMyContext();

app.Run();
