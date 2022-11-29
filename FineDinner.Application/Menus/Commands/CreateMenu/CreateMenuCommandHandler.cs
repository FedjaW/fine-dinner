using FineDinner.Domain.MenuAggregate;

using ErrorOr;
using MediatR;
using FineDinner.Domain.MenuAggregate.Entities;
using FineDinner.Domain.HostAggregate.ValueObjects;

namespace FineDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Create Menu
        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description)))));

        // Persist Menu

        // Return Menu

        return default!;
    }
}