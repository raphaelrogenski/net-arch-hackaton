using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Application.Orders.Validators;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders.Events;
using System.ComponentModel.DataAnnotations;
namespace NetArchHackaton.Shared.Application.Orders.Commands
{
    public class ProduceCreateOrderHandler : IProduceCreateOrderHandler
    {
        private readonly IMessageService messageService;
        private readonly OnCreateOrderValidator validator;

        public ProduceCreateOrderHandler(IMessageService messageService, OnCreateOrderValidator validator)
        {
            this.messageService = messageService;
            this.validator = validator;
        }

        public async Task HandleAsync(string userEmail, CreateOrderRequest request)
        {
            validator.EnsureValidation(userEmail, request);

            var items = request.Items.ToDictionary(r => r.Id, r => r.Quantity);

            var @event = new OrderCreateEvent(userEmail, request.DeliveryMethod, items);
            messageService.Publish(@event);
        }
    }
}
