using System.Text.Json.Serialization;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Core.Domain;
using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using CycleBike.Core.Domain.Services.Events;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CycleBike.Adapters.OutboxRelay.Middlewares;

public static class DependencyInjectionLayer
{
    public static void AddMiddlewares(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDomain();
        services.AddNoSqlLayer(opt =>
        {
            opt.PropertyNameCaseInsensitive = true;
            opt.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        });
        services.AddInfrastructure(configuration);
        services.AddScoped<IConsumerStrategy<OutboxEnvelope>, RegisterProductEvent<OutboxEnvelope>>();

        services.AddOpenTelemetry()
            .WithTracing(tracing => {
                tracing.AddSource("Wolverine")
                    .AddAspNetCoreInstrumentation()
                    .AddOtlpExporter();
            })
            .WithMetrics(metrics => {
                metrics.AddMeter("Wolverine")
                    .AddOtlpExporter();
            });
    }
}