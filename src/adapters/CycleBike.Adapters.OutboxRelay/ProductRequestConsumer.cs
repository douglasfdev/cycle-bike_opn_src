using CycleBike.Core.Domain.Interfaces;
using CycleBike.Core.Domain.Modules.Events.Envelopes;
using Wolverine.Attributes;

namespace CycleBike.Adapters.OutboxRelay;

[WolverineHandler]
public class ProductRequestConsumer(IConsumerStrategy<OutboxEnvelope> strategy)
{
    public async Task Handle(OutboxEnvelope @event)
    {
        await strategy.HandleAsync(@event);
    }
}