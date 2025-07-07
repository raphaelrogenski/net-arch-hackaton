namespace NetArchHackaton.Shared.Contracts.Kitchen.DTOs
{
    public class GetKitchenOrderResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string DeliveryMethod { get; set; }
        public IList<GetKitchenOrderItemResponse> Items { get; set; }
    }
}
