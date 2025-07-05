using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetArchHackaton.OrderService.Consumers;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Domain.Orders.Events;

namespace NetArchHackaton.OrderService.Workers
{
    public class ConsumersWorker : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public ConsumersWorker(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = scopeFactory.CreateScope()) 
            {
                var messageService = scope.ServiceProvider.GetRequiredService<IMessageService>();
                var createConsumer = scope.ServiceProvider.GetRequiredService<OrderCreateConsumer>();
                var cancelConsumer = scope.ServiceProvider.GetRequiredService<OrderCancelConsumer>();

                messageService.Consume<OrderCreateEvent>(createConsumer.Handle);
                messageService.Consume<OrderCancelEvent>(cancelConsumer.Handle);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
