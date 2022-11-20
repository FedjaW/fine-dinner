using FineDinner.Domain.Common.Models;
using FineDinner.Domain.Dinner.ValueObjects;

namespace FineDinner.Domain.Dinner.Entities;

public sealed class Price : Entity<PriceId>
{
    public double Amount { get; }
    public string Currency { get; }

    private Price(
        PriceId priceId,
        double amount,
        string currency)
        : base(priceId)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(double amount, string currency)
    {
        return new(PriceId.CreateUnique(), amount, currency);
    }
}