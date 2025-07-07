using NetArchHackaton.Shared.Contracts.Kitchen.DTOs;

namespace NetArchHackaton.Shared.Contracts.Kitchen.Commands
{
    public interface IRejectKitchenOrderHandler
    {
        Task<bool> HandleAsync(string userEmail, Guid id, CancelKitchenOrderRequest request);
    }
}
