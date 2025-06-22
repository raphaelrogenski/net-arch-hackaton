using NetArchHackaton.Shared.Application.Base.Exceptions;

namespace NetArchHackaton.Shared.Application.Auth.Exceptions
{
    public class InvalidRoleException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Invalid Role!";

        public InvalidRoleException() 
            : base(Message)
        {
        }
    }
}
