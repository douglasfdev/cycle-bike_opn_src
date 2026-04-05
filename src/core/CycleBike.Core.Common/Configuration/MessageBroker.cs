using Wolverine.RabbitMQ;

namespace CycleBike.Core.Common.Configuration;

public class MessageBroker
{
    public required string ConnectionString { get; init; }
    public required List<RabbitMqExchange> Exchanges { get; init; } = new();
}

public class RabbitMqExchange
{
    public required string Process { get; init; }
    public required string Name { get; init; }
    public required string Type { get; init; }
    public required bool Durable { get; init; }
    public required List<Queues> Queues { get; init; } = default!;
    
    public ExchangeType ResolveType(string type)
    {
        if (Enum.TryParse<ExchangeType>(type, ignoreCase: true, out var result))
        {
            return result;
        }
    
        throw new ArgumentOutOfRangeException(nameof(type), type, "Tipo de Exchange não suportado.");
    }
}

public class Queues
{
    public required string Name { get; init; }
    public required string RoutingKey { get; init; }
}
