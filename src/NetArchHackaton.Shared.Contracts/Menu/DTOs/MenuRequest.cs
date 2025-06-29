namespace NetArchHackaton.Shared.Contracts.Menu.DTOs
{
    public class MenuRequest
    {
        public string Category { get; set; }
        public bool OnlyAvailable { get; set; }
        public string Search { get; set; }
    }
}
