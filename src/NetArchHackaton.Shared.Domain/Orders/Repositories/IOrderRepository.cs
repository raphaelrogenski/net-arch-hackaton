namespace NetArchHackaton.Shared.Domain.Orders
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Order GetOrderDetails(string userEmail, Guid id);
    }
}
