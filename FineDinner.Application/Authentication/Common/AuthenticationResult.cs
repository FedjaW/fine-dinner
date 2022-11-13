using FineDinner.Domain.Entities;

namespace FineDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
