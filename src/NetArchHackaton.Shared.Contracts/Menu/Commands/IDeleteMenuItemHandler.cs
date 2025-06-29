namespace NetArchHackaton.Shared.Contracts.Menu.Commands
{
    public interface IDeleteMenuItemHandler
    {
        Task<bool> HandleAsync(Guid id);
    }
}
