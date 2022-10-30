using FineDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FineDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationControllre : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return this.Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return this.Ok(request);
    }
}