using CycleBike.Core.Common.Configuration;
using CycleBike.Core.Common.Interfaces;

namespace CycleBike.Core.Common.MessageBroker.Providers;

public class ExchangeProvider : IExchangeProvider
{
    private List<RabbitMqExchange> _exchanges => EnvironmentVariable
        .TryGetEnvironment<Configuration.MessageBroker>(nameof(Configuration.MessageBroker)).Exchanges;

    public ExchangeResource GetExchange(string process, string routingKey)
    {
        var exchange = _exchanges.FirstOrDefault(e =>
                           e.Process.Equals(process, StringComparison.InvariantCultureIgnoreCase))
                       ?? throw new InvalidOperationException($"Exchange para processo '{process}' não encontrado.");

        var queue = exchange.Queues.FirstOrDefault(q =>
                        q.RoutingKey.Equals(routingKey, StringComparison.InvariantCultureIgnoreCase))
                    ?? throw new InvalidOperationException($"RoutingKey '{routingKey}' não encontrada em '{process}'.");

        return new ExchangeResource(exchange.Name, exchange.Type, queue.RoutingKey);
    }
}