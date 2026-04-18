using CycleBike.Adapters.SocketAdapter;
using CycleBike.Core.Common.Configuration;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace CycleBike.Adapters.NotificationWorker.Middlewares;

public static class DependencyInjectionLayer
{
    public static void AddMiddlewares(this IServiceCollection services)
    {
        services.AddSocketAdapter(options =>
        {
            var signalR = EnvironmentVariable.TryGetEnvironment<SignalROptions>(nameof(SignalROptions));
            options = options with
            {
                HubUrl = signalR.HubUrl,
                AutomaticReconnect = signalR.AutomaticReconnect,
                ReconnectDelays = signalR.ReconnectDelays,
                HandshakeTimeout = signalR.HandshakeTimeout,
                KeepAliveInterval = signalR.KeepAliveInterval,
                ServerTimeout = signalR.ServerTimeout,
                Headers = signalR.Headers
            };
        });

        services.AddOpenTelemetry()
            .WithTracing(tracing => tracing
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("NotificationWorker"))
                .AddHttpClientInstrumentation() 
                .AddEntityFrameworkCoreInstrumentation()
                .AddSource(nameof(NotificationWorker))
                .AddOtlpExporter());
    }
}