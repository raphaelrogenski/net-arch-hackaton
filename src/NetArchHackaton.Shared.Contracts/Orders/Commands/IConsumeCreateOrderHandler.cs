using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Commands
{
    public interface IConsumeCreateOrderHandler
    {
        Task<bool> HandleAsync(string userEmail, CreateOrderRequest request);
    }
}
