using System.Text.Json.Serialization;
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
            options = options with
            {
                HubUrl = EnvironmentVariable.SignalR().HubUrl,
                AutomaticReconnect = EnvironmentVariable.SignalR().AutomaticReconnect,
                ReconnectDelays = EnvironmentVariable.SignalR().ReconnectDelays,
                HandshakeTimeout = EnvironmentVariable.SignalR().HandshakeTimeout,
                KeepAliveInterval = EnvironmentVariable.SignalR().KeepAliveInterval,
                ServerTimeout = EnvironmentVariable.SignalR().ServerTimeout,
                Headers = EnvironmentVariable.SignalR().Headers
            };
        });
        services.AddDomain();
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