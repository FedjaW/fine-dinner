using FluentValidation;

namespace FineDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommanValidator : AbstractValidator<CreateMenuCommand>
{

    public CreateMenuCommanValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Sections).NotEmpty();
    }
}