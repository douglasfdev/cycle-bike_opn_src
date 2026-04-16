using CycleBike.Core.Domain.Modules.Entities;

namespace CycleBike.Adapters.GraphQL.Subscriptions;

[ExtendObjectType("Subscription")]
public class ProductSubscription
{
    [Subscribe]
    [Topic("ProductCreated")]
    public Product OnProductCreated(
        [EventMessage] Product product) => product;

    [Subscribe]
    [Topic("ProductUpdated")]
    public Product OnProductUpdated(
        [EventMessage] Product product) => product;

    [Subscribe]
    [Topic("ProductDeleted")]
    public Product OnProductDeleted(
        [EventMessage] Product product) => product;
}
