using FineDinner.Domain.User;

namespace FineDinner.Application.Common.Interfaces.Persitence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}