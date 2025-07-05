namespace NetArchHackaton.Shared.Domain.Orders.Events
{
    public record OrderCreateEvent(string userEmail, string deliveryMethod, IDictionary<Guid, int> items);
}
