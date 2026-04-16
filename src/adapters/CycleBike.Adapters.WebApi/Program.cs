using CycleBike.Adapters.GraphQL.Configuration;
using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.SocketServerAdapter.RealTime.Hubs;
using CycleBike.Adapters.WebApi.Middlewares;
using CycleBike.Core.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.InitializeEnvironments();
builder.Services.AddMiddlewares(builder.Configuration);
builder.Host.AddServiceBus();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
builder.Services.AddGraphQLAdapter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.MapHub<NotificationsHub>("/realtime");
app.MapGraphQLAdapter();
app.UseHttpsRedirection();

app.Run();