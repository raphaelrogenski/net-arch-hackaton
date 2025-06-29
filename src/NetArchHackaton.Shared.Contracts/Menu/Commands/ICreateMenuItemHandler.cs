using NetArchHackaton.Shared.Contracts.Menu.DTOs;

namespace NetArchHackaton.Shared.Contracts.Menu.Commands
{
    public interface ICreateMenuItemHandler
    {
        Task<Guid> HandleAsync(CommandMenuItemRequest request);
    }
}
