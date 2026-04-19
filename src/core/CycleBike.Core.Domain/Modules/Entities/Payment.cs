using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.ValueObjects;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Payment : AggregateRoot
{
    public Ulid OrderId { get; set; }
    public Ulid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    
    public string Status { get; set; } = "pending";
    public string? TransactionDetails { get; set; }
    public string TransactionId { get; set; } = string.Empty;
    public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Cria uma nova instância de Payment.
    /// </summary>
    public Payment() : base(default!) { }

    
    /// <summary>
    /// Cria uma nova instância de Payment.
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="paymentMethodId"></param>
    /// <param name="money"></param>
    /// <param name="paymentMethod"></param>
    /// <param name="createdBy">O Identificador de quem criou</param>
    private Payment(Ulid orderId, Ulid paymentMethodId, Money money, PaymentMethod paymentMethod, string createdBy) : base(createdBy)
    {
        OrderId = orderId;
        PaymentMethodId = paymentMethodId;
        PaymentMethod = paymentMethod;
        Amount = money.Amount;
        Currency = money.Currency;
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
    }

    public static Payment Create(Ulid orderId, Ulid paymentMethodId, Money money, PaymentMethod paymentMethod, string createdBy)
        => new(orderId, paymentMethodId, money, paymentMethod, createdBy);
    
    public void SetPaid(string transactionId, string? details = null)
    {
        Status = "Paid";
        TransactionId = transactionId;
        TransactionDetails = details;
        ProcessedAt = DateTime.UtcNow;
    }
    
    public void SetFailed(string? reason = null)
    {
        Status = "Failed";
        TransactionDetails = reason;
        ProcessedAt = DateTime.UtcNow;
    }
}