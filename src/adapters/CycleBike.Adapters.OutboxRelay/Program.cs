using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.OutboxRelay.Configuration;
using CycleBike.Adapters.OutboxRelay.Middlewares;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Logging;
using CycleBike.Core.Common.MessageBroker;
using Wolverine.Attributes;

[assembly: WolverineModule]
var host = Host.CreateDefaultBuilder(args);
host.ConfigureLogging(logging => logging.AddOpenTelemetryDomainInjection());
host.ConfigureServices((ctx, services) =>
    {
        ctx.Configuration.InitializeEnvironments();
        services.AddMiddlewares(ctx.Configuration);
        var hostEnvironmentAdapter = new HostEnvironmentAdapter(ctx.HostingEnvironment);
        host.UseServiceBus(hostEnvironmentAdapter, opts => opts.ListenToExchangeQueues("ProductRegistration"));
    });

var app = host.Build();

await app.RunAsync();