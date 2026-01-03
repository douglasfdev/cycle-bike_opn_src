using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Middlewares;
using CycleBike.Core.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Services.AddDIMiddlewares(builder.Configuration);

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