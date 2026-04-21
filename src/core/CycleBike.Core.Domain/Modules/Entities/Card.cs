using CycleBike.Core.Domain.Aggregates;
using CycleBike.Core.Domain.Enums;

namespace CycleBike.Core.Domain.Modules.Entities;

public class Card : AggregateRoot
{
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string LastFourDigits { get; set; } = string.Empty;
    public string CardToken { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string ExpirationDate { get; set; } = string.Empty;
    public string Cvv { get; set; } = string.Empty;

    public Card() : base(default!) {}

    private Card(string cardToken, string lastFourDigits, string number, PaymentType type, string holderName, string expirationDate, string cvv, string createdBy): base(createdBy)
    {
        CardToken = cardToken;
        LastFourDigits = lastFourDigits;
        Number = number;
        Type = type.ToString().ToUpperInvariant();
        HolderName = holderName;
        ExpirationDate = expirationDate;
        Cvv = cvv;
        CreatedBy = createdBy;
    }

    /// <summary>
    /// Cria uma nova instância de Card.
    /// </summary>
    /// <param name="cardToken">O token do cartão.</param>
    /// <param name="lastFourDigits">Os últimos quatro dígitos do cartão.</param>
    /// <param name="number">O número do cartão.</param>
    /// <param name="type">O tipo do cartão.</param>
    /// <param name="holderName">O nome do portador do cartão.</param>
    /// <param name="expirationDate">A data de expiração do cartão.</param>
    /// <param name="cvv">O CVV do cartão.</param>
    /// <param name="createdBy">O identificador de quem criou.</param>
    public static Card Create(string cardToken, string lastFourDigits, string number, PaymentType type, string holderName,
        string expirationDate, string cvv, string createdBy)
        => new (cardToken, lastFourDigits, number, type, holderName, expirationDate, cvv, createdBy);
}