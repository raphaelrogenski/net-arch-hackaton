using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Commands
{
    public interface IProduceCancelOrderHandler
    {
        Task HandleAsync(string userEmail, Guid id, CancelOrderRequest request);
    }
}
