using FineDinner.Domain.UserAggregate;

namespace FineDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
