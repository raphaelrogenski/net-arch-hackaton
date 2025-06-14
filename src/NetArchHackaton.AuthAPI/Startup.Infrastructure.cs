using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Domain.Users;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Users;

namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
