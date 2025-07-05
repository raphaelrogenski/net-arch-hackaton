namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderPendingException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Pending!";

        public OrderPendingException() 
            : base(Message)
        {
        }
    }
}
