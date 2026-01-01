using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Order : AggregateRoot
{
    public Ulid Id { get; set; }
    public string CustomerId { get; set; }
    public Customer Customer { get; set; } = new();
    public string ProductId { get; set; }
    public Product Product { get; set; } = new();
    public string Status { get; set; }

    /// <summary>
    /// Cria uma nova instância de Order.
    /// </summary>
    public Order() { }

    /// <summary>
    /// Cria uma nova instância de Order com cliente e produto.
    /// </summary>
    /// <param name="customerId">O cliente do pedido.</param>
    /// <param name="productId">O produto do pedido.</param>
    public Order(string customerId, string productId)
    {
        CustomerId = customerId;
        ProductId = productId;
        Status = "pending";
    }
}