using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Domain.User;

namespace FineDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }
}