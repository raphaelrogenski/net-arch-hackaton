namespace NetArchHackaton.Shared.Contracts.Kitchen.Commands
{
    public interface IFinishKitchenOrderHandler
    {
        Task<bool> HandleAsync(string userEmail, Guid id);
    }
}
