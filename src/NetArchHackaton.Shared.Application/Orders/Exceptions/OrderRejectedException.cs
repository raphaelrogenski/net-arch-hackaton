namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderRejectedException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Rejected!";

        public OrderRejectedException() 
            : base(Message)
        {
        }
    }
}
