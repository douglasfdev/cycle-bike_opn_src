using CycleBike.Adapters.NotificationWorker;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Core.Common.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.InitializeEnvironments();
builder.Services.AddSocketAdapter(options =>
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

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();