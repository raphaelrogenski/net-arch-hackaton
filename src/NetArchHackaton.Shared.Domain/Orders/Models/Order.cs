using NetArchHackaton.Shared.Domain.OrderItems;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Domain.Orders
{
    public class Order : EntityBase
    {
        public OrderStatusEnum Status { get; set; }
        public OrderDeliveryMethodEnum DeliveryMethod { get; set; }
        public string CancelReason { get; set; }
        public Guid IdCustomer { get; set; }
        public User Customer { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
