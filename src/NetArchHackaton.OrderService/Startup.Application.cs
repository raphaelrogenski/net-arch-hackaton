using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetArchHackaton.OrderService.Consumers;
using NetArchHackaton.Shared.Application.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.Commands;

namespace NetArchHackaton.OrderService
{
    public partial class Startup
    {
        private void ConfigureApplication(IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddScoped<IConsumeCreateOrderHandler, ConsumeCreateOrderHandler>();
                services.AddScoped<IConsumeCancelOrderHandler, ConsumeCancelOrderHandler>();

                services.AddScoped<OrderCreateConsumer>();
                services.AddScoped<OrderCancelConsumer>();
            });
        }
    }
}
