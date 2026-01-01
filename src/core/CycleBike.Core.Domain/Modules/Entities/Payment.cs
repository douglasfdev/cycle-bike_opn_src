using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.ValueObjects;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Payment : AggregateRoot
{
    public Ulid Id { get; set; }
    public Ulid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    
    public string Status { get; set; } = "pending";
    public string TransactionId { get; set; } = string.Empty;
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Cria uma nova instância de Payment.
    /// </summary>
    public Payment() { }
    
    /// <summary>
    /// Cria uma nova instância de Payment.
    /// </summary>
    /// <param name="paymentMethodId"></param>
    /// <param name="money"></param>
    /// <param name="status"></param>
    /// <param name="transactionId"></param>
    public Payment(Ulid paymentMethodId, Money money, string status, string transactionId)
    {
        PaymentMethodId = paymentMethodId;
        Amount = money.Amount;
        Currency = money.Currency;
        Status = status;
        TransactionId = transactionId;
        ProcessedAt = DateTime.UtcNow;
    }
}