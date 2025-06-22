using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class InvalidUserOrPasswordException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Invalid User Or Password!";

        public InvalidUserOrPasswordException() 
            : base(Message)
        {
        }
    }
}
