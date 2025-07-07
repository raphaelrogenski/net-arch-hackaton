using NetArchHackaton.Shared.Contracts.Kitchen.DTOs;
using NetArchHackaton.Shared.Contracts.Kitchen.Queries;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Application.Kitchen.Queries
{
    public class GetKitchenOrdersHandler : IGetKitchenOrdersHandler
    {
        private readonly IOrderRepository orderRepository;

        public GetKitchenOrdersHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IList<GetKitchenOrderResponse>> HandleAsync()
        {
            var status = new[] { OrderStatusEnum.Pending, OrderStatusEnum.InProgress };
            var orders = orderRepository.Query(false).Where(r => status.Contains(r.Status));

            var response = orders.Select(order => new GetKitchenOrderResponse()
            {
                Id = order.Id,
                Created = order.Created,
                CustomerName = order.Customer.FullName,
                Status = order.Status.ToString(),
                DeliveryMethod = order.DeliveryMethod.ToString(),
                Items = order.Items.Select(item => new GetKitchenOrderItemResponse()
                {
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Category = item.Product.Category,
                    Quantity = item.Quantity,
                }).ToList(),
            }).ToList();

            return response;
        }
    }
}
