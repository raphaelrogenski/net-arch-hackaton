﻿using Microsoft.AspNetCore.Identity;
using NetArchHackaton.Shared.Application.Auth.Exceptions;
using NetArchHackaton.Shared.Application.Auth.Validators;
using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.DTOs;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Application.Auth.Commands
{
    public class RegisterEmployeeHandler : IRegisterEmployeeHandler
    {
        private readonly IUserRepository userRepository;

        public RegisterEmployeeHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> HandleAsync(RegisterEmployeeRequest request)
        {
            var exists = userRepository.Query(false).Any(r => r.Email == request.Email);
            if (exists)
            {
                throw new EmailOrCPFAlreadyExistsException();
            }

            var isValidEmail = EmailValidator.IsValid(request.Email);
            if (!isValidEmail)
            {
                throw new InvalidEmailException();
            }

            var isValidPassword = PasswordSecurityValidator.IsValid(request.Password);
            if (!isValidPassword)
            {
                throw new InvalidPasswordException();
            }

            var role = request.GetRole();
            if (role == UserRoleEnum.Unknown)
            {
                throw new InvalidRoleException();
            }

            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Role = role,
            };

            user.PasswordHash = hasher.HashPassword(user, request.Password);

            userRepository.Create(user);

            return true;
        }
    }
}
