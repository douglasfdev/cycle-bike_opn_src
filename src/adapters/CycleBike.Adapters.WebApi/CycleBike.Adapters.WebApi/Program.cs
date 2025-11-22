using CycleBike.Adapters.HttpClient;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Configuration;
using CycleBike.Core.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Services.AddCustomApiVersioning();
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
builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddHttpClientAdapter();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.MapHub<NotificationsHub>("/realtime");
app.UseHttpsRedirection();

app.Run();