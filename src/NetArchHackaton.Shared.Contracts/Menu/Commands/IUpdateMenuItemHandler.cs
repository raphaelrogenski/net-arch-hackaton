using NetArchHackaton.Shared.Contracts.Menu.DTOs;

namespace NetArchHackaton.Shared.Contracts.Menu.Commands
{
    public interface IUpdateMenuItemHandler
    {
        Task<bool> HandleAsync(Guid id, CommandMenuItemRequest request);
    }
}
