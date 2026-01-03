namespace CycleBike.Core.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; }

    public Money(decimal amount, string? currency)
    {
        if (amount < 0)
            throw new ArgumentException($"{nameof(amount)} cannot be negative.");
        Amount = amount;
        Currency = currency ?? "BRL";
    }
}