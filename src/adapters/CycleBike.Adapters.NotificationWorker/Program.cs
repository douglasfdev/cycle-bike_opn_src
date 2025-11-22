using CycleBike.Adapters.NotificationWorker;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Core.Common.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.InitializeEnvironments();
builder.Services.AddSocketAdapter(options =>
{
    options = options with
    {
        HubUrl = EnvironmentVariable.SignalROptions.HubUrl,
        AutomaticReconnect = EnvironmentVariable.SignalROptions.AutomaticReconnect,
        ReconnectDelays = EnvironmentVariable.SignalROptions.ReconnectDelays,
        HandshakeTimeout = EnvironmentVariable.SignalROptions.HandshakeTimeout,
        KeepAliveInterval = EnvironmentVariable.SignalROptions.KeepAliveInterval,
        ServerTimeout = EnvironmentVariable.SignalROptions.ServerTimeout,
        Headers = EnvironmentVariable.SignalROptions.Headers
    };
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();