using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders.Events;

namespace NetArchHackaton.OrderService.Consumers
{
    public class OrderCreateConsumer
    {
        private readonly IConsumeCreateOrderHandler handler;

        public OrderCreateConsumer(IConsumeCreateOrderHandler handler)
        {
            this.handler = handler;
        }

        public async Task Handle(OrderCreateEvent @event)
        {
            Console.WriteLine("Handling OrderCreatedEvent");

            var userEmail = @event.userEmail;
            var request = new CreateOrderRequest()
            {
                DeliveryMethod = @event.deliveryMethod,
                Items = @event.items.Select(r => new OrderItemRequest()
                {
                    Id = r.Key,
                    Quantity = r.Value
                }).ToList()
            };

            await handler.HandleAsync(userEmail, request);
        }
    }
}
