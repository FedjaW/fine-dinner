using System.Diagnostics;
using System.ComponentModel;
using FineDinner.Application.Menus.Commands.CreateMenu;
using FineDinner.Contracts.Menus;
using FineDinner.Domain.MenuAggregate;

using Mapster;

using MenuSection = FineDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = FineDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace FineDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0) // last 0 should be replaced with null
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}