using System.Text.Json.Serialization;
using Cycle.Core.Application;
using CycleBike.Adapters.GenericHttpClient;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Adapters.WebApi.Configuration;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Domain;

namespace CycleBike.Adapters.WebApi.Middlewares;

public static class DependencyInjectionLayer
{
    public static void AddMiddlewares(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomApiVersioning();
        services.AddOpenApi();
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
        services.AddDomain();
        services.AddApplicationLayer();
        services.AddSignalR();
        services.AddHttpClientAdapter();

        
        services.AddNoSqlLayer(opt =>
        {
            opt.PropertyNameCaseInsensitive = true;
            opt.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        });
        services.AddInfrastructure(configuration);
    }
}