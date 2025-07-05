namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderInProgressException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order In Progress!";

        public OrderInProgressException() 
            : base(Message)
        {
        }
    }
}
