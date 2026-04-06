using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Interfaces;
using Wolverine;
using Wolverine.RabbitMQ;
using Wolverine.RabbitMQ.Internal;
using RabbitMqExchange = CycleBike.Core.Common.Configuration.RabbitMqExchange;

namespace CycleBike.Core.Common.MessageBroker;

public static class WolverineExtensions
{
    /// <summary>
    /// Declara todos os exchanges e suas bindings configurados no appsettings.
    /// </summary>
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

    /// <summary>
    /// Configura listeners para todas as filas de um exchange espec�fico.
    /// </summary>
    public static WolverineOptions ListenToExchangeQueues(
        this WolverineOptions opts,
        string exchangeProcess, params Type[] messageTypes)
    {
        var exchanges = EnvironmentVariable
            .TryGetEnvironment<Configuration.MessageBroker>(nameof(MessageBroker)).Exchanges;

        var exchange = exchanges.FirstOrDefault(e =>
                           e.Process.Equals(exchangeProcess, StringComparison.OrdinalIgnoreCase))
                       ?? throw new InvalidOperationException($"Exchange '{exchangeProcess}' n�o encontrado.");

        for (var i = 0; i < exchange.Queues.Count; i++)
        {
            var listener = opts.ListenToRabbitQueue(exchange.Queues[i].Name.ToLowerInvariant());

            if (i < messageTypes.Length)
                listener.DefaultIncomingMessage(messageTypes[i]);
        }

        return opts;
    }
    
    /// <summary>
    /// Configura publishers para todos os exchanges usando a conven��o de routing.
    /// </summary>
    public static WolverineOptions RegisterTopicRouters(this WolverineOptions opts)
    {
        var exchanges = EnvironmentVariable
            .TryGetEnvironment<Configuration.MessageBroker>(nameof(Configuration.MessageBroker)).Exchanges;

        foreach (var exchange in exchanges)
        {
            // Configura publisher para o exchange
            opts.PublishAllMessages().ToRabbitExchange(exchange.Name.ToLowerInvariant());
        }

        return opts;
    }
}