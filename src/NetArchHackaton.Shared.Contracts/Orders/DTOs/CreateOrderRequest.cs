using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Contracts.Orders.DTOs
{
    public class CreateOrderRequest
    {
        public string DeliveryMethod { get; set; }
        public List<OrderItemRequest> Items { get; set; }

        public OrderDeliveryMethodEnum GetDeliveryMethod()
        {
            if (Enum.TryParse<OrderDeliveryMethodEnum>(DeliveryMethod, out var deliveryMethod))
            {
                return deliveryMethod;
            }
            else
            {
                return OrderDeliveryMethodEnum.Unknown;
            }
        }
    }
}
