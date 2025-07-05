namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderNotFoundException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Not Found!";

        public OrderNotFoundException() 
            : base(Message)
        {
        }
    }
}
