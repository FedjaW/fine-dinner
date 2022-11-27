using FineDinner.Contracts.Menus;
using Microsoft.AspNetCore.Mvc;

namespace FineDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    [HttpPost]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        return Ok(request);
    }
}
