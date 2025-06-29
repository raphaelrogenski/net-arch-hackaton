using NetArchHackaton.Shared.Contracts.Menu.DTOs;

namespace NetArchHackaton.Shared.Contracts.Menu.Queries
{
    public interface IGetMenuHandler
    {
        Task<MenuResponse> HandleAsync(MenuRequest request);
    }
}
