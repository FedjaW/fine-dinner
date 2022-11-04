using FineDinner.Application.Common.Interfaces.Services;

namespace FineDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}