using FineDinner.Domain.Common.Models;

namespace FineDinner.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public double Amount { get; }
    public string Currency { get; }

    private Price(
        double amount,
        string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Price CreateNew(
        double amount,
        string currency)
    {
        return new Price(
            amount,
            currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}