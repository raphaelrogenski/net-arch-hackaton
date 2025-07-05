using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Queries
{
    public interface IGetOrderByIdHandler
    {
        Task<OrderResponse> HandleAsync(string userEmail, Guid id);
    }
}
