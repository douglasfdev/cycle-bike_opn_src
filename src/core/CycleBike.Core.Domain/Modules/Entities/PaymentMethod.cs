using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Modules.Entities;

public class PaymentMethod : AggregateRoot
{
    public Ulid ProfileId { get; set; }
    public string PaymentType { get; set; }
    public Ulid? CardId { get; set; }
    public Card? Card { get; set; }
    
    /// <summary>
    /// Cria uma nova instância de PaymentMethod.
    /// </summary>
    public PaymentMethod() : base(default!){ }
    
    
    /// <summary>
    /// Cria uma nova instância de PaymentMethod.
    /// </summary>
    /// <param name="paymentType"></param>
    /// <param name="cardId"></param>
    /// <param name="createdBy">O Identificador de quem criou</param>
    private PaymentMethod(PaymentType paymentType, Ulid cardId, string createdBy) : base(createdBy)
    {
        PaymentType = paymentType.ToString().ToUpperInvariant();
        CardId = cardId;
        CreatedBy = createdBy;
    }

    public static PaymentMethod Create(PaymentType paymentType, Ulid cardId, string createdBy)
        => new(paymentType, cardId, createdBy);
}