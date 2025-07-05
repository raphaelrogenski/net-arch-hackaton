using NetArchHackaton.Shared.Application.Menu;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Application.Orders.Commands
{
    public class ConsumeCancelOrderHandler : IConsumeCancelOrderHandler
    {
        private readonly IOrderRepository orderRepository;

        public ConsumeCancelOrderHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<bool> HandleAsync(string userEmail, Guid id, CancelOrderRequest request)
        {
            var order = orderRepository.Query().SingleOrDefault(r => r.Customer.Email == userEmail && r.Id == id);
            if (order == null)
            {
                throw new OrderNotFoundException();
            }

            if (order.Status == OrderStatusEnum.InProgress)
            {
                throw new OrderInProgressException();
            }

            if (order.Status == OrderStatusEnum.Ready)
            {
                throw new OrderReadyException();
            }

            if (order.Status == OrderStatusEnum.Cancelled)
            {
                throw new OrderCancelledException();
            }

            if (order.Status == OrderStatusEnum.Rejected)
            {
                throw new OrderRejectedException();
            }

            order.Status = OrderStatusEnum.Cancelled;
            order.CancelReason = request.CancelReason;

            orderRepository.Update(order);

            return true;
        }
    }
}
