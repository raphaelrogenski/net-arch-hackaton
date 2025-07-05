using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Domain.Orders.Events;
using System.Text.Json;

namespace NetArchHackaton.DQLMonitor.Functions
{
    public class OrderCreatedDQLFunction
    {
        private readonly ILogger _logger;
        private readonly IMessageService _messageService;

        public OrderCreatedDQLFunction(ILoggerFactory loggerFactory, IMessageService messageService)
        {
            _logger = loggerFactory.CreateLogger<OrderCreatedDQLFunction>();
            _messageService = messageService;
        }

        [Function("OrderCreatedDQLFunction")]
        public void Run([TimerTrigger("*/30 * * * * *")] TimerInfo myTimer)
        {
            while (true)
            {
                var message = _messageService.ConsumeFromDLQ<OrderCreateEvent>();
                if (message == null)
                {
                    _logger.LogInformation("No messages in CreateDLQ");
                    break;
                }

                _logger.LogWarning("OrderCreatedDQL Received: {0}", JsonSerializer.Serialize(message));
            }
        }
    }
}
