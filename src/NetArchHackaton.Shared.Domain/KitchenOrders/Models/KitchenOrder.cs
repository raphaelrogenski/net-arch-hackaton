using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Domain.KitchenOrders
{
    public class KitchenOrder : EntityBase
    {
        public KitchenOrderStatusEnum Status { get; set; }
        public string Notes { get; set; }
        public Guid IdOrder { get; set; }
        public Guid IdHandledBy { get; set; }
        public Order Order { get; set; }
        public User HandledBy { get; set; }
    }
}
