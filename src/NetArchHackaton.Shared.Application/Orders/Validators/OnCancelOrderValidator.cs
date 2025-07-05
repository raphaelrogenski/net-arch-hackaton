using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Application.Orders.Validators
{
    public class OnCancelOrderValidator
    {
        private readonly IOrderRepository orderRepository;

        public OnCancelOrderValidator(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        internal void EnsureValidation(string customerEmail, Guid id, CancelOrderRequest request)
        {
            EnsureValidation(customerEmail, id, request.CancelReason);
        }

        internal void EnsureValidation(string userEmail, Guid id, string cancelReason)
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
        }
    }
}
