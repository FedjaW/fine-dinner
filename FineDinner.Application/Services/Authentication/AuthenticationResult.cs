using FineDinner.Domain.Entities;

namespace FineDinner.Application.Services.Authentication;

public record AuthenticationResult(User User, string Token);