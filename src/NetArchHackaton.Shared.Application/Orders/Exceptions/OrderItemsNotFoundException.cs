namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderItemsNotFoundException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Order Items Not Found!";

        public OrderItemsNotFoundException() 
            : base(Message)
        {
        }
    }
}
