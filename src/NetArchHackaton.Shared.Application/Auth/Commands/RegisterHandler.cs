using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Application.Auth.Commands
{
    public class RegisterHandler : IRegisterHandler
    {
        private readonly IUserRepository userRepository;

        public RegisterHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> HandleAsync(RegisterRequest request)
        {
            var exists = userRepository.Query(false).Any(r => r.Email == request.Email);
            if (exists)
            {
                throw new ApplicationException();
            }

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = request.Password,
                //Role = request.Role,
            };

            userRepository.Create(user);

            return true;
        }
    }
}
