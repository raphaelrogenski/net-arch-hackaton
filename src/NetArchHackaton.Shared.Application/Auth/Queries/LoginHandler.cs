using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Contracts.Auth.Queries;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Application.Auth.Queries
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IUserRepository userRepository;

        public LoginHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<LoginResponse> HandleAsync(LoginRequest request)
        {
            var user = userRepository.Query(false)
                .FirstOrDefault(r => r.Email == request.User || r.CPF == request.User);

            if (user == null)
            {
                throw new ApplicationException();
            }

            return new LoginResponse()
            {
                Token = string.Empty
            };
        }
    }
}
