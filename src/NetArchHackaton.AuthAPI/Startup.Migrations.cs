using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;

namespace NetArchHackaton.AuthAPI
{
    public partial class Startup
    {
        private void UseMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = AppDbContextFactory.CreateDbContext(app.Configuration);
                context.Database.Migrate();

                DatabaseSeeder.SeedAsync(app.Services).Wait();
            }
		}
    }
}
