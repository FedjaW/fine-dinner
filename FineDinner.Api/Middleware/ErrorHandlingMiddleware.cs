using System.Net;
using System.Text.Json;

namespace FineDinner.Api.Middleware;

// ATTENTION!
// Just left this here as an example of what a different approach to error handling looks like.
[Obsolete]
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request" });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}

// Add this to the request pipeline in Program.cs to use this approach. 
// app.UseMiddleware<ErrorHandlingMiddleware>();