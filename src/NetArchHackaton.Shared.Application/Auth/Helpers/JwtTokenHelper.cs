using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NetArchHackaton.Shared.Domain.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetArchHackaton.Shared.Application.Auth.Helpers
{
    public class JwtTokenHelper
    {
        private readonly IConfiguration configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        internal string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var jwtKey = configuration["Jwt:Key"]!;
            var jwtIssuer = configuration["Jwt:Issuer"]!;
            var jwtAudience = configuration["Jwt:Audience"]!;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
