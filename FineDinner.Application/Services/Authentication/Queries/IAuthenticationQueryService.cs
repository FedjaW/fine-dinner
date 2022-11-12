using ErrorOr;
using FineDinner.Application.Services.Authentication.Common;

namespace FineDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}