using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Domain.OrderItems
{
    public class OrderItem : EntityBase
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid IdOrder { get; set; }
        public Guid IdProduct { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
