using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using FineDinner.Application.Common.Errors;

namespace FineDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost("/error")]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexcepted error occured.")
        };

        return Problem(title: message, statusCode: statusCode);
    }
}

// See: https://learn.microsoft.com/de-de/aspnet/core/web-api/handle-errors?view=aspnetcore-7.0