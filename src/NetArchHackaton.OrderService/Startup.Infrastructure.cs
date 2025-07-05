using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Domain.KitchenOrders;
using NetArchHackaton.Shared.Domain.OrderItems;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Domain.Users;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Messaging;
using NetArchHackaton.Shared.Infrastructure.Orders;
using NetArchHackaton.Shared.Infrastructure.Products;
using NetArchHackaton.Shared.Infrastructure.Users;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<IMessageService, RabbitMQService>();

                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IOrderRepository, OrderRepository>();
                services.AddScoped<IUserRepository, UserRepository>();
            });
        }
    }
}
