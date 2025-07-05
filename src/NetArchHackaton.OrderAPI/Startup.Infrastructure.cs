using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Domain.Users;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Messaging;
using NetArchHackaton.Shared.Infrastructure.Orders;
using NetArchHackaton.Shared.Infrastructure.Products;
using NetArchHackaton.Shared.Infrastructure.Users;

namespace NetArchHackaton.OrderAPI
{
    public partial class Startup
    {
        private void ConfigureInfrastructure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMessageService, RabbitMQService>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            
        }
    }
}
