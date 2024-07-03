using System.Linq;
using DotNetCoreApiSample.Api;
using DotNetCoreApiSample.Api.Middleware.ApiExceptionHandler;
using DotNetCoreApiSample.Api.Middleware.MyContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMyContextAccessor, MyContextAccessor>();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(document =>
{
    document.AddSecurity("Bearer", [], new OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Description = "Type into the textbox: {your JWT token}."
    });

    document.OperationProcessors.Add(
        new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
});
builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApiDescriptionProvider, CamelCaseQueryParametersApiDescriptionProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UsePathBase("/app");
//app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
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

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

app.UseMyContext();

app.Run();
