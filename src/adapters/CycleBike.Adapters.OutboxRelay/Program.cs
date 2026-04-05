using CycleBike.Adapters.Infrastructure;
using CycleBike.Adapters.OutboxRelay;
using CycleBike.Adapters.OutboxRelay.Middlewares;
using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.MessageBroker;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using Wolverine.Attributes;

[assembly: WolverineModule]
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, services) =>
    {
        ctx.Configuration.InitializeEnvironments();
        services.AddMiddlewares(ctx.Configuration);
    })
    .AddServiceBus(opts =>
    {
        var transport = opts.ListenToExchangeQueues("ProductRequests", typeof(OutboxEnvelope));
        Console.WriteLine(transport.DescribeHandlerMatch(typeof(ProductRequestConsumer)));
    })
    .Build();

await host.RunAsync();