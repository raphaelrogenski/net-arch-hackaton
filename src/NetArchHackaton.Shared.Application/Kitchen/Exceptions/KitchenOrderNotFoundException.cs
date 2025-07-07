namespace NetArchHackaton.Shared.Application.Kitchen.Exceptions
{
    public class KitchenOrderNotFoundException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Kitchen Order Not Found!";

        public KitchenOrderNotFoundException()
            : base(Message)
        {
        }
    }
}
