using CycleBike.Adapters.NotificationWorker;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Core.Common.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.InitializeEnvironments();
builder.Services.AddSocketAdapter(options =>
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

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();