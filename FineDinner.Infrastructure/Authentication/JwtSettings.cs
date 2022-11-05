namespace FineDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;

    // Hint: null! -> null forgiving operator
    // See: https://stackoverflow.com/questions/54724304/what-does-null-statement-mean
}