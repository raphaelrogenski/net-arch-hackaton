namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderDuplicatedItemsException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Items are Duplicated!";

        public OrderDuplicatedItemsException() 
            : base(Message)
        {
        }
    }
}
