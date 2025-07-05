namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderItemsNotAvailableException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Items Not Available!";

        public OrderItemsNotAvailableException() 
            : base(Message)
        {
        }
    }
}
