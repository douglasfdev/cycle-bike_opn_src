using CycleBike.Core.Domain.Aggregates;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Order : AggregateRoot
{
    public Ulid CustomerId { get; set; }
    public Customer Customer { get; set; } = new();
    public Ulid ProductId { get; set; }
    public Product Product { get; set; } = new();
    public string Status { get; set; }
    public Ulid? PaymentId { get; set; }
    public Payment Payment { get; set; } = new();

    /// <summary>
    /// Cria uma nova instância de Order.
    /// </summary>
    public Order() { }

    /// <summary>
    /// Cria uma nova instância de Order com cliente e produto.
    /// </summary>
    /// <param name="customerId">O cliente do pedido.</param>
    /// <param name="productId">O produto do pedido.</param>
    public Order(Ulid customerId, Ulid productId)
    {
        CustomerId = customerId;
        ProductId = productId;
        Status = "pending";
    }
    
    public void AddPayment(Ulid paymentId)
    {
        PaymentId = paymentId;
        Status = "Processing";
    }
}