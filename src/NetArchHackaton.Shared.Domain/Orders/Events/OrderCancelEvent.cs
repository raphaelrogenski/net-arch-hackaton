namespace NetArchHackaton.Shared.Domain.Orders.Events
{
    public record OrderCancelEvent(string userEmail, Guid idOrder, string cancelReason);
}
