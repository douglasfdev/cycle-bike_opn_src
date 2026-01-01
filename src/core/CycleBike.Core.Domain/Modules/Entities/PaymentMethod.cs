using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Modules.Entities;

public class PaymentMethod : AggregateRoot
{
    public Ulid Id { get; set; }
    public string PaymentType { get; set; }
    public Ulid OrderId { get; set; }
    public Order Order { get; set; }
    
    /// <summary>
    /// Cria uma nova instância de PaymentMethod.
    /// </summary>
    public PaymentMethod() { }
    
    
    /// <summary>
    /// Cria uma nova instância de PaymentMethod.
    /// </summary>
    /// <param name="paymentType"></param>
    /// <param name="orderId"></param>
    public PaymentMethod(PaymentType paymentType, Ulid orderId)
    {
        PaymentType = paymentType.ToString().ToUpperInvariant();
        OrderId = orderId;
    }
}