namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderItemUnavailableException : Base.Exceptions.ApplicationException
    {
        private const string Message = "At least one of the selected items is unavailable!";

        public OrderItemUnavailableException()
            : base(Message)
        {
        }
    }
}
