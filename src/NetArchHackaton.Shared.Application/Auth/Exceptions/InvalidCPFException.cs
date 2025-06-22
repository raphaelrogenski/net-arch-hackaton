using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class InvalidCPFException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Invalid CPF Format!";

        public InvalidCPFException() 
            : base(Message)
        {
        }
    }
}
