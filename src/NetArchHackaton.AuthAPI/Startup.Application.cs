using NetArchHackaton.Shared.Application.Auth.Queries;
using NetArchHackaton.Shared.Contracts.Auth.Queries;

namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ILoginHandler, LoginHandler>();
        }
    }
}
