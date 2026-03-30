using CycleBike.Adapters.OutboxRelay;
using CycleBike.Adapters.OutboxRelay.Middlewares;
using CycleBike.Core.Common.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.InitializeEnvironments();
builder.Services.AddMiddlewares(builder.Configuration);

builder.Services.BuildServiceProvider().GetService<Worker>();

var host = builder.Build();
host.Run();