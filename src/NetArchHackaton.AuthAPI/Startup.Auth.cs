using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureAuth(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
        }

        private void UseAuth(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
