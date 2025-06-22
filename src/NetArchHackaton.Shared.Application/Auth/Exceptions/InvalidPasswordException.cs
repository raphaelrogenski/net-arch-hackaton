using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class InvalidPasswordException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Your password must have at least 8 characters, including one uppercase letter, one lowercase letter, one number, and one special character.";

        public InvalidPasswordException() 
            : base(Message)
        {
        }
    }
}
