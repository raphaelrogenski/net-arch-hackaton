namespace NetArchHackaton.Shared.Contracts.Menu.DTOs
{
    public class QueryMenuItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
    }
}
