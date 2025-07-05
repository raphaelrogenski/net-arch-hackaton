namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderCancelledException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Cancelled!";

        public OrderCancelledException() 
            : base(Message)
        {
        }
    }
}
