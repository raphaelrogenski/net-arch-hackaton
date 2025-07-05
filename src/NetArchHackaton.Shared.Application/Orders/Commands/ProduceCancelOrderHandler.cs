using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Application.Orders.Validators;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders.Events;

namespace NetArchHackaton.Shared.Application.Orders.Commands
{
    public class ProduceCancelOrderHandler : IProduceCancelOrderHandler
    {
        private readonly IMessageService messageService;
        private readonly OnCancelOrderValidator validator;

        public ProduceCancelOrderHandler(IMessageService messageService, OnCancelOrderValidator validator)
        {
            this.messageService = messageService;
            this.validator = validator;
        }

        public async Task HandleAsync(string userEmail, Guid id, CancelOrderRequest request)
        {
            validator.EnsureValidation(userEmail, id, request);

            var @event = new OrderCancelEvent(userEmail, id, request.CancelReason);
            messageService.Publish(@event);
        }
    }
}
