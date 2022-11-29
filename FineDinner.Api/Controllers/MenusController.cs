using FineDinner.Application.Menus.Commands.CreateMenu;
using FineDinner.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace FineDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createdMenuResult = await _mediator.Send(command);

        return createdMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }
}
