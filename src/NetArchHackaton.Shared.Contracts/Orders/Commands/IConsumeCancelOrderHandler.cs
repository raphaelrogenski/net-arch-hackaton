using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Commands
{
    public interface IConsumeCancelOrderHandler
    {
        Task<bool> HandleAsync(string userEmail, Guid id, CancelOrderRequest request);
    }
}
