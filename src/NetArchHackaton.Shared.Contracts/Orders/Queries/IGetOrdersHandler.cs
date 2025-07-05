using NetArchHackaton.Shared.Contracts.Orders.DTOs;

namespace NetArchHackaton.Shared.Contracts.Orders.Queries
{
    public interface IGetOrdersHandler
    {
        Task<IList<OrderResponse>> HandleAsync(string userEmail);
    }
}
