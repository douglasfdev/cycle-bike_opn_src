using Asp.Versioning.ApiExplorer;
using CycleBike.Adapters.GraphQL.Configuration;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Middlewares;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Logging.AddOpenTelemetryDomainInjection();

builder.Services.AddMiddlewares(builder.Configuration);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();

var app = builder.Build();
builder.Host.UseServiceBus(app.Environment, x => x.Discovery.DisableConventionalDiscovery());

// app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

app.MapGet("/health", async (ILoggerFactory log, HttpContext ctx) =>
{
    var logger = log.CreateLogger("HealthCheck");
    logger.LogInformation("Health check endpoint is OK");
    logger.LogInformation("Path recebido: {0}", ctx.Request.Path);
    await ctx.Response.WriteAsync("OK");
});

app.MapControllers();
app.MapHub<NotificationsHub>("/realtime");
app.MapGraphQLAdapter();

app.Run();