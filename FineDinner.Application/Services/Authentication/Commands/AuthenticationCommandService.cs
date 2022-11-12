using ErrorOr;
using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Application.Services.Authentication.Common;
using FineDinner.Domain.Entities;

namespace FineDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user does not exist.
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicatedEmail;
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
        var token = _jwtTokenGenerator.GenerateToken(newUser);

        return new AuthenticationResult(newUser, token);
    }
}