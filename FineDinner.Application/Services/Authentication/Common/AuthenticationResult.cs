using FineDinner.Domain.Entities;

namespace FineDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(User User, string Token);