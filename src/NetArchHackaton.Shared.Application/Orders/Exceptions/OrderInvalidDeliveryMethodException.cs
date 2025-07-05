namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class OrderInvalidDeliveryMethodException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Invalid Order Delivery Method!";

        public OrderInvalidDeliveryMethodException() 
            : base(Message)
        {
        }
    }
}
