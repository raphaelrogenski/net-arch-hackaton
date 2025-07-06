using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Domain.KitchenOrders;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Users;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.OrderItems;
using NetArchHackaton.Shared.Infrastructure.Orders;
using NetArchHackaton.Shared.Infrastructure.Users;

namespace NetArchHackaton.KitchenAPI
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IKitchenOrderRepository, KitchenOrderRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
