using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Products;

namespace NetArchHackaton.MenuAPI
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
