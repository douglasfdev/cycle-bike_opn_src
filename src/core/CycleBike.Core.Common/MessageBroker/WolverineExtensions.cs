using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Interfaces;
using Wolverine;
using Wolverine.RabbitMQ;
using Wolverine.RabbitMQ.Internal;

namespace CycleBike.Core.Common.MessageBroker;

public static class WolverineExtensions
{
    public static RabbitMqTransportExpression DeclareExchanges(this RabbitMqTransportExpression transport)
    {
        var exchangeList = EnvironmentVariable.TryGetEnvironment<Configuration.MessageBroker>(nameof(Configuration.MessageBroker)).Exchanges;

        foreach (var exchangeOpts in exchangeList)
        {
            transport.DeclareExchange(exchangeOpts.Name.ToLowerInvariant(), exchange =>
            {
                exchange.IsDurable = exchangeOpts.Durable;
                exchange.ExchangeType = exchangeOpts.ResolveType(exchangeOpts.Type);
                exchangeOpts.Queues.ForEach(queueOpts =>
                {
                    exchange.BindQueue(queueOpts.Name.ToLowerInvariant(), queueOpts.RoutingKey.ToLowerInvariant());
                });
            });
        }

        return transport;
    }

    public static WolverineOptions ListenToExchangeQueues(
        this WolverineOptions opts,
        string exchangeProcess, params Type[] messageTypes)
    {
        var exchanges = EnvironmentVariable
            .TryGetEnvironment<Configuration.MessageBroker>(nameof(MessageBroker)).Exchanges;

        var exchange = exchanges.FirstOrDefault(e =>
                           e.Process.Equals(exchangeProcess, StringComparison.OrdinalIgnoreCase))
                       ?? throw new InvalidOperationException($"Exchange '{exchangeProcess}' não encontrado.");

        for (var i = 0; i < exchange.Queues.Count; i++)
        {
            var listener = opts.ListenToRabbitQueue(exchange.Queues[i].Name.ToLowerInvariant());

            if (i < messageTypes.Length)
                listener.DefaultIncomingMessage(messageTypes[i]);
        }

        return opts;
    }
    
    public static WolverineOptions RegisterTopicRouters(this WolverineOptions opts)
    {
        var exchanges = EnvironmentVariable
            .TryGetEnvironment<Configuration.MessageBroker>(nameof(Configuration.MessageBroker)).Exchanges;

        foreach (var exchange in exchanges)
        {
            opts.PublishMessagesToRabbitMqExchange<IMessageBroker>(
                exchange.Name.ToLowerInvariant(),
                msg =>
                {
                    var queue = exchange.Queues.FirstOrDefault(e => e.RoutingKey.Equals("initial", StringComparison.InvariantCultureIgnoreCase));
                    return queue?.RoutingKey.ToLowerInvariant() ?? string.Empty;
                });

        }

        return opts;
    }
}