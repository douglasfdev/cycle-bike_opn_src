using CycleBike.Core.Common.Configuration;
using Wolverine.RabbitMQ.Internal;

namespace CycleBike.Core.Common.Exchanges;

public static class WolverineExtensions
{
    public static RabbitMqTransportExpression DeclareExchanges(this RabbitMqTransportExpression transport)
    {
        var exchangeList = EnvironmentVariable.MessageBroker().Exchanges;

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
}