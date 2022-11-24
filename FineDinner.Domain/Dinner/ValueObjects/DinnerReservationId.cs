using FineDinner.Domain.Common.Models;

namespace FineDinner.Domain.Dinner.ValueObjects;

public sealed class DinnerReservationId : ValueObject
{
    public Guid Value { get; }

    private DinnerReservationId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
