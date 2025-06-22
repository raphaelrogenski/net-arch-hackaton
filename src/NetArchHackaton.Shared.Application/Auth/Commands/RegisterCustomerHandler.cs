using Microsoft.AspNetCore.Identity;
using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Application.Auth.Commands
{
    public class RegisterCustomerHandler : IRegisterCustomerHandler
    {
        private readonly IUserRepository userRepository;

        public RegisterCustomerHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> HandleAsync(RegisterCustomerRequest request)
        {
            var exists = userRepository.Query(false).Any(r => r.Email == request.Email || r.CPF == request.CPF);
            if (exists)
            {
                throw new Base.Exceptions.ApplicationException("");
            }

            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                CPF = request.CPF,
                Role = UserRoleEnum.Customer,
            };

            user.PasswordHash = hasher.HashPassword(user, request.Password);

            userRepository.Create(user);

            return true;
        }
    }
}
