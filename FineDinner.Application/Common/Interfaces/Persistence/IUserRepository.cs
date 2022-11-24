using FineDinner.Domain.UserAggregate;

namespace FineDinner.Application.Common.Interfaces.Persitence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}