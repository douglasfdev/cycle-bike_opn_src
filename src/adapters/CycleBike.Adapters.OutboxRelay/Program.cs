using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.OutboxRelay.Middlewares;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Logging;
using Wolverine.Attributes;

[assembly: WolverineModule]
var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging => logging.AddOpenTelemetryDomainInjection())
    .ConfigureServices((ctx, services) =>
    {
        ctx.Configuration.InitializeEnvironments();
        services.AddMiddlewares(ctx.Configuration);
    })
    .AddServiceBus()
    .Build();

await host.RunAsync();