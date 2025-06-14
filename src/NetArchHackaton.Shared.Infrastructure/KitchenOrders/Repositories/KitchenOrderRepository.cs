using NetArchHackaton.Shared.Domain.KitchenOrders;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Repositories;

namespace NetArchHackaton.Shared.Infrastructure.OrderItems
{
    public class KitchenOrderRepository : RepositoryBase<KitchenOrder>, IKitchenOrderRepository
    {
        public KitchenOrderRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
