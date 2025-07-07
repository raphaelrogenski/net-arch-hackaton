namespace NetArchHackaton.Shared.Contracts.Kitchen.Commands
{
    public interface IAcceptKitchenOrderHandler
    {
        Task<bool> HandleAsync(string userEmail, Guid id);
    }
}
