using CycleBike.Core.Common.Interfaces;
using CycleBike.Core.Common.MessageBroker;
using CycleBike.Core.Domain.Interfaces;
using Wolverine;

namespace CycleBike.Core.Domain.Services;

public class MessagePublisher(IMessageBus bus, IExchangeProvider exchangeProvider) : IMessagePublisher
{
    public async Task PublishAsync<T>(T @event, string process, string routingKey) where T : class
    {
        var routingKeyEnum = ParseRoutingKey(routingKey);
        var exchangeResource = exchangeProvider.GetExchange(process, routingKey);

        var metadata = RoutingMetadata.ForProcess(process, routingKeyEnum);
        
        if (@event is IRoutableMessage routable)
        {
            routable.RoutingMetadata = metadata;
        }

        var opts = new DeliveryOptions();
        opts.Headers.Add("x-process", process);
        opts.Headers.Add("x-routing-key", routingKeyEnum.ToRoutingKeyString().ToLowerInvariant());
        opts.Headers.Add("x-exchange", exchangeResource.Exchange);
        opts.Headers.Add("x-correlation-id", metadata.CorrelationId);

        await bus.SendAsync(@event, opts);

        Console.WriteLine($"[Publisher] Evento enviado para '{exchangeResource.Exchange}' com routing key '{routingKeyEnum}' (Correlation: {metadata.CorrelationId})");
    }

    private static RoutingKey ParseRoutingKey(string routingKey)
    {
        if (Enum.TryParse<RoutingKey>(routingKey, ignoreCase: true, out var result))
            return result;
        
        throw new ArgumentException($"Routing key '{routingKey}' não é válida. Valores válidos: {string.Join(", ", Enum.GetNames<RoutingKey>())}");
    }
}
