using ErrorOr;
using FineDinner.Application.Authentication.Common;
using FineDinner.Application.Common.Interfaces.Authentication;
using FineDinner.Application.Common.Interfaces.Persitence;
using FineDinner.Domain.Common.Errors;
using FineDinner.Domain.UserAggregate;
using MediatR;

namespace FineDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // to get rid of the warning that async method has no await

        // 1. Validate the user does not exist.
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicatedEmail;
        }

        // 2. Create a user (generate a unique id) & persist to DB
        var newUser = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );
        _userRepository.AddUser(newUser);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(newUser);

        return new AuthenticationResult(newUser, token);
    }
}

