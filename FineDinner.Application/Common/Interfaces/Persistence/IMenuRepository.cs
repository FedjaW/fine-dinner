using FineDinner.Domain.MenuAggregate;

namespace FineDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}