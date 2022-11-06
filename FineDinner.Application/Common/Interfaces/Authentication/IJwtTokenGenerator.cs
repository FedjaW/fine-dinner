using FineDinner.Domain.Entities;

namespace FineDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

