namespace NetArchHackaton.Shared.Application.Orders.Exceptions
{
    public class UserNotFoundException : Base.Exceptions.ApplicationException
    {
        private const string Message = "User Not Found!";

        public UserNotFoundException()
            : base(Message)
        {
        }
    }
}
