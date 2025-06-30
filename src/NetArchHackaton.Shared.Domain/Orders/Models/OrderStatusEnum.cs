namespace NetArchHackaton.Shared.Domain.Orders
{
    public enum OrderStatusEnum : short
    {
        Pending = 1,
        InProgress = 2,
        Ready = 3,
        Cancelled = 4,
        Rejected = 5
    }
}
