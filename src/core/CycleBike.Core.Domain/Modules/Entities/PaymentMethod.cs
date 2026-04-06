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
    public PaymentMethod() { }
    
    
    /// <summary>
    /// Cria uma nova instância de PaymentMethod.
    /// </summary>
    /// <param name="paymentType"></param>
    /// <param name="cardId"></param>
    public PaymentMethod(PaymentType paymentType, Ulid cardId)
    {
        PaymentType = paymentType.ToString().ToUpperInvariant();
        CardId = cardId;
    }

    /// <summary>
    /// Cria uma nova instância de PaymentMethod para outros tipos (PIX, Boleto, etc.).
    /// </summary>
    /// <param name="profileId">O ID do perfil do cliente.</param>
    /// <param name="paymentType">O tipo de pagamento.</param>
    public PaymentMethod(Ulid profileId, PaymentType paymentType)
    {
        PaymentType = paymentType.ToString().ToUpperInvariant();
        ProfileId = profileId;
    }
}