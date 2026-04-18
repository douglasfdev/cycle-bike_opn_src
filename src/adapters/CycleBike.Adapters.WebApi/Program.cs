using Asp.Versioning.ApiExplorer;
using CycleBike.Adapters.GraphQL.Configuration;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Middlewares;
using CycleBike.Core.Common.Configuration;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
    logging.AddOtlpExporter();
});

builder.Configuration.InitializeEnvironments();
builder.Services.AddMiddlewares(builder.Configuration);
builder.Host.AddServiceBus();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();

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
    logger.LogInformation("Health check endpoint was called.");
    await ctx.Response.WriteAsync("OK");
});

app.MapControllers();
app.MapHub<NotificationsHub>("/realtime");
app.MapGraphQLAdapter();
app.UseHttpsRedirection();

app.Run();