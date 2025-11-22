using System.Text.Json.Serialization;
using CycleBike.Adapters.GenericHttpClient;
using CycleBike.Adapters.NoSQLContext;
using CycleBike.Adapters.SocketAdapter;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Configuration;
using CycleBike.Core.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Services.AddCustomApiVersioning();
builder.Services.AddOpenApi();
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
builder.Services.AddSignalR();
builder.Services.AddHttpClientAdapter();
builder.Services.AddNoSqlLayer(builder.Configuration, opt =>
{
    opt.PropertyNameCaseInsensitive = true;
    opt.NumberHandling = JsonNumberHandling.AllowReadingFromString;
});
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