using ErrorOr;
using FineDinner.Application.Authentication.Common;
using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Domain.Common.Errors;
using MediatR;

namespace FineDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // to get rid of the warning that async method has no await

        // 1. Validate the user exists
        var user = _userRepository.GetUserByEmail(query.Email);
        if (user is null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the Password is correct
        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Create a JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }
}
