using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Contracts.Auth.DTOs
{
    public class RegisterEmployeeRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public UserRoleEnum GetRole()
        {
            if (Enum.TryParse<UserRoleEnum>(Role, ignoreCase: true, out var role))
            {
                return role;
            }
            else
            {
                return UserRoleEnum.Unknown;
            }
        }
    }
}
