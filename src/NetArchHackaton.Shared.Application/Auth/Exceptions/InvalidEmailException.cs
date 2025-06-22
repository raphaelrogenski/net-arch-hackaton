using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class InvalidEmailException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Invalid Email Format!";

        public InvalidEmailException() 
            : base(Message)
        {
        }
    }
}
