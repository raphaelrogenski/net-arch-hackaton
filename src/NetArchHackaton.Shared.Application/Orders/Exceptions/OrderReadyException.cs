namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderReadyException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Ready!";

        public OrderReadyException() 
            : base(Message)
        {
        }
    }
}
