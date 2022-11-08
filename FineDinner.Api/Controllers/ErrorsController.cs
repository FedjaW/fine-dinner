using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace FineDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost("/error")]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;
        var code = 500; // Internal Server Error by default

        // Handle http status code of custom exceptions (examples)
        // if (exception is NotFoundException) code = 404; // Not Found
        // else if (exception is UnauthException) code = 401; // Unauthorized

        return Problem(
            title: exception?.Message,
            statusCode: code);
    }
}

// See: https://learn.microsoft.com/de-de/aspnet/core/web-api/handle-errors?view=aspnetcore-7.0