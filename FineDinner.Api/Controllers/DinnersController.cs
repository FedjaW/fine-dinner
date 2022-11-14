using Microsoft.AspNetCore.Mvc;

namespace FineDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinnerts()
    {
        return Ok(Array.Empty<string>());
    }
}