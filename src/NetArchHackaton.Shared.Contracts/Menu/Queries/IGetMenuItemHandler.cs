using NetArchHackaton.Shared.Contracts.Menu.DTOs;

namespace NetArchHackaton.Shared.Contracts.Menu.Queries
{
    public interface IGetMenuItemHandler
    {
        Task<QueryMenuItemResponse> HandleAsync(Guid id);
    }
}
