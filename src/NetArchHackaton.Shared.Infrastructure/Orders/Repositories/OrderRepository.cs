using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Repositories;

namespace NetArchHackaton.Shared.Infrastructure.Orders
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
