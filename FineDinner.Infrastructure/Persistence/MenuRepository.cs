using FineDinner.Application.Common.Interfaces.Persistence;
using FineDinner.Domain.MenuAggregate;

namespace FineDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}