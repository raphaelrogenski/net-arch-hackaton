using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders.Events;

namespace NetArchHackaton.OrderService.Consumers
{
    public class OrderCancelConsumer
    {
        private readonly IConsumeCancelOrderHandler handler;

        public OrderCancelConsumer(IConsumeCancelOrderHandler handler)
        {
            this.handler = handler;
        }

        public async Task Handle(OrderCancelEvent @event)
        {
            Console.WriteLine("Handling OrderCancelEvent");

            var userEmail = @event.userEmail;
            var id = @event.idOrder;
            var request = new CancelOrderRequest()
            {
                CancelReason = @event.cancelReason
            };

            await handler.HandleAsync(userEmail, id, request);
        }
    }
}
