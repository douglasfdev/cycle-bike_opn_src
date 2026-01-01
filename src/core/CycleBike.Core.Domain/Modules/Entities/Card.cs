using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Card : AggregateRoot
{
    public Ulid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string ExpirationDate { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    
    /// <summary>
    /// Cria uma nova instância de Card.
    /// </summary>
    public Card() { }
    
    
    /// <summary>
    /// Cria uma nova instância de Card.
    /// </summary>
    /// <param name="number">O número do cartão.</param>
    /// <param name="type">O tipo do cartão.</param>
    /// <param name="holderName">O nome do portador do cartão.</param>
    /// <param name="expirationDate">A data de expiração do cartão.</param>
    /// <param name="cvv">O CVV do cartão.</param>
    public Card(string number, PaymentType type, string holderName, string expirationDate, string cvv)
    {
        Number = number;
        Type = type.ToString().ToUpperInvariant();
        HolderName = holderName;
        ExpirationDate = expirationDate;
        CVV = cvv;
    }
}