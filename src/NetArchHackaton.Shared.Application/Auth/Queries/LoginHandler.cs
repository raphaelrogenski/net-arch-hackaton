
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetArchHackaton.Shared.Application.Auth.Exceptions;
using NetArchHackaton.Shared.Application.Auth.Helpers;
using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Contracts.Auth.Queries;
using NetArchHackaton.Shared.Domain.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetArchHackaton.Shared.Application.Auth.Queries
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IUserRepository userRepository;
        private readonly JwtTokenHelper jwtTokenHelper;

        public LoginHandler(IUserRepository userRepository, JwtTokenHelper jwtTokenHelper)
        {
            this.userRepository = userRepository;
            this.jwtTokenHelper = jwtTokenHelper;
        }

        public async Task<LoginResponse> HandleAsync(LoginRequest request)
        {
            var user = userRepository.Query(false)
                .FirstOrDefault(r => r.Email == request.User || r.CPF == request.User);

            if (user == null)
            {
                throw new InvalidUserOrPasswordException();
            }

            var hasher = new PasswordHasher<User>();
            var passwordVerificationResult = hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                throw new InvalidUserOrPasswordException();
            }

            var token = jwtTokenHelper.GenerateToken(user);
            return new LoginResponse()
            {
                Token = token,
            };
        }
    }
}
