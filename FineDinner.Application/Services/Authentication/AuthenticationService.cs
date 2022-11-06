using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Domain.Entities;

namespace FineDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user does not exist.
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception($"User with given email {email} does already exists.");
        }

        // 2. Create a user (generate a unique id) & persist to DB
        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.AddUser(newUser);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(newUser.Id, firstName, lastName);

        return new AuthenticationResult(newUser.Id, firstName, lastName, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists.
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
        {
            throw new Exception($"User with given email {email} does not exist."); // todo: this message is a vector for hackers. Change it!
        }

        // 2. Validate the Password is correct.
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // 3. Create a JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthenticationResult(user.Id, user.FirstName, user.LastName, email, token);
    }
}