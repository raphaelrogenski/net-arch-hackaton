namespace NetArchHackaton.Shared.Contracts.Orders.DTOs
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Status { get; set; }
        public string DeliveryMethod { get; set; } 
        public string CancelReason { get; set; }
        public decimal OrderPrice { get; set; }
        public IList<OrderItemResponse> Items { get; set; }
    }
}
