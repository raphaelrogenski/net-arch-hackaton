using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Domain.Orders.Events;
using System.Text.Json;

namespace NetArchHackaton.DQLMonitor.Functions
{
    public class OrderCancelledDQLFunction
    {
        private readonly ILogger _logger;
        private readonly IMessageService _messageService;

        public OrderCancelledDQLFunction(ILoggerFactory loggerFactory, IMessageService messageService)
        {
            _logger = loggerFactory.CreateLogger<OrderCancelledDQLFunction>();
            _messageService = messageService;
        }

        [Function("OrderCancelledDQLFunction")]
        public void Run([TimerTrigger("*/30 * * * * *")] TimerInfo myTimer)
        {
            while (true)
            {
                var message = _messageService.ConsumeFromDLQ<OrderCancelEvent>();
                if (message == null)
                {
                    _logger.LogInformation("No messages in CancelDLQ");
                    break;
                }

                _logger.LogWarning("OrderCancelledDQL Received: {0}", JsonSerializer.Serialize(message));
            }
        }
    }
}
