using CycleBike.Core.Domain.Modules.Entities;
using HotChocolate.Subscriptions;

namespace CycleBike.Adapters.GraphQL.Subscriptions;

public class ProductTopicEventSender
{
    private readonly ITopicEventSender _eventSender;

    public ProductTopicEventSender(ITopicEventSender eventSender)
    {
        _eventSender = eventSender;
    }

    public async Task PublishCreatedAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _eventSender.SendAsync("ProductCreated", product, cancellationToken);
    }

    public async Task PublishUpdatedAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _eventSender.SendAsync("ProductUpdated", product, cancellationToken);
    }

    public async Task PublishDeletedAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _eventSender.SendAsync("ProductDeleted", product, cancellationToken);
    }
}
