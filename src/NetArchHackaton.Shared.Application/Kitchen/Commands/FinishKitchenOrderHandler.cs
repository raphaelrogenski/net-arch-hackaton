using NetArchHackaton.Shared.Application.Kitchen.Exceptions;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Kitchen.Commands;
using NetArchHackaton.Shared.Domain.KitchenOrders;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Application.Kitchen.Commands
{
    public class FinishKitchenOrderHandler : IFinishKitchenOrderHandler
    {
        private readonly IKitchenOrderRepository kitchenOrderRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;

        public FinishKitchenOrderHandler(IKitchenOrderRepository kitchenOrderRepository, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            this.kitchenOrderRepository = kitchenOrderRepository;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
        }

        public async Task<bool> HandleAsync(string userEmail, Guid id)
        {
            var user = userRepository.Query(false).SingleOrDefault(r => r.Email == userEmail);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var order = orderRepository.Query(true).SingleOrDefault(r => r.Id == id);
            if (order == null)
            {
                throw new OrderNotFoundException();
            }

            if (order.Status == OrderStatusEnum.Pending)
            {
                throw new OrderPendingException();
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

            var kitchenOrder = kitchenOrderRepository.Query(true).SingleOrDefault(r => r.IdOrder == id);
            if (kitchenOrder == null)
            {
                throw new KitchenOrderNotFoundException();
            }

            kitchenOrder.Status = KitchenOrderStatusEnum.Finished;
            kitchenOrderRepository.Update(kitchenOrder);

            order.Status = OrderStatusEnum.Ready;
            orderRepository.Update(order);

            return true;
        }
    }
}
