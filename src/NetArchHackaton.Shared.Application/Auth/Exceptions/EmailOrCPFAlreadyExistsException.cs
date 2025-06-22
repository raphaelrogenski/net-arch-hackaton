using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class EmailOrCPFAlreadyExistsException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Email or CPF already exists!";

        public EmailOrCPFAlreadyExistsException() 
            : base(Message)
        {
        }
    }
}
