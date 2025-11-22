using CycleBike.Adapters.SocketAdapter.Abstractions;
using CycleBike.Adapters.SocketAdapter.Configuration;
using CycleBike.Adapters.SocketAdapter.Services;
using CycleBike.Core.Common.Configuration;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CycleBike.Adapters.SocketAdapter;

public static class SocketAdapterDependencyInjectionLayer
{
    public static void AddSocketAdapter(
        this IServiceCollection services,
        Action<SignalROptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);

        var options = new SignalROptions
        {
            HubUrl = EnvironmentVariable.SignalR().HubUrl,
        };
        configureOptions(options);

        services.AddSingleton<ISocketAdapter>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<SignalRService>>();
            
            var builder = new HubConnectionBuilder()
                .WithUrl(options.HubUrl, httpOptions =>
                {
                    if (options.Headers is not null)
                    {
                        foreach (var header in options.Headers)
                        {
                            httpOptions.Headers.Add(header.Key, header.Value);
                        }
                    }
                })
                .WithAutomaticReconnect((options.AutomaticReconnect 
                    ? new CustomRetryPolicy(options.ReconnectDelays) 
                    : null)!)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                });

            builder.Services.Configure<HubConnectionOptions>(hubOptions =>
            {
                hubOptions.KeepAliveInterval = options.KeepAliveInterval;
                hubOptions.ServerTimeout = options.ServerTimeout;
            });

            var connection = builder.Build();
            return new SignalRService(connection, logger);
            
        });
    }
}