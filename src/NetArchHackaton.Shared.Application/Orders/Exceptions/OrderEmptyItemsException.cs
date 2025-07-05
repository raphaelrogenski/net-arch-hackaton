namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderEmptyItemsException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Items are Empty!";

        public OrderEmptyItemsException() 
            : base(Message)
        {
        }
    }
}
