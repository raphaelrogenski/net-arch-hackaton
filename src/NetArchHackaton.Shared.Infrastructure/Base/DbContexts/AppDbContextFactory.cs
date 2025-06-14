using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NetArchHackaton.Shared.Infrastructure.Base.DbContexts
{
    public static class AppDbContextFactory
    {
        public static AppDbContext CreateDbContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
