using CycleBike.Adapters.NotificationWorker;
using CycleBike.Adapters.NotificationWorker.Middlewares;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddOpenTelemetryDomainInjection();
builder.Configuration.InitializeEnvironments();
builder.Services.AddMiddlewares();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();