using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using Wolverine.Attributes;

namespace CycleBike.Adapters.OutboxRelay;

[WolverineHandler]
public class ProductRequestConsumer(ILogger<ProductRequestConsumer> _logger,IConsumerStrategy<OutboxEnvelope> strategy)
{
    public async Task Handle(OutboxEnvelope @event)
    {
        _logger.LogInformation(
            "[OUTBOX RELAY] Received event: Id={Id}, Type={Type}, OccurredAt={OccurredAt}",
            @event.Id, @event.MessageType, @event.CreatedAt
            );
        await strategy.HandleAsync(@event);
    }
}