using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Commands
{
    public interface IProduceCreateOrderHandler
    {
        Task HandleAsync(string userEmail, CreateOrderRequest request);
    }
}
