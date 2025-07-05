namespace NetArchHackaton.Shared.Contracts.Orders.DTOs
{
    public class OrderItemResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
    }
}
