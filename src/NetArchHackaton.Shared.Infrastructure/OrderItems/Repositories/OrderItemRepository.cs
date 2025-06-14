using NetArchHackaton.Shared.Domain.OrderItems;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Repositories;

namespace NetArchHackaton.Shared.Infrastructure.OrderItems
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
