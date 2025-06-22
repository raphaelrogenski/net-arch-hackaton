using NetArchHackaton.Shared.Application.Auth.Commands;
using NetArchHackaton.Shared.Application.Auth.Helpers;
using NetArchHackaton.Shared.Application.Auth.Queries;
using NetArchHackaton.Shared.Contracts.Auth.Commands;
using NetArchHackaton.Shared.Contracts.Auth.Queries;

namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<JwtTokenHelper>();
            builder.Services.AddScoped<ILoginHandler, LoginHandler>();
            builder.Services.AddScoped<IRegisterCustomerHandler, RegisterCustomerHandler>();
            builder.Services.AddScoped<IRegisterEmployeeHandler, RegisterEmployeeHandler>();
        }
    }
}
