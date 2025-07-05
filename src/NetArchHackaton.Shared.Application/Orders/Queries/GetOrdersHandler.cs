using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Contracts.Orders.Queries;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Application.Orders.Queries
{
    public class GetOrdersHandler : IGetOrdersHandler
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IList<OrderResponse>> HandleAsync(string userEmail)
        {
            var orders = orderRepository.Query(false).Where(r => r.Customer.Email == userEmail);

            var response = orders.Select(order => new OrderResponse
            {
                Id = order.Id,
                Created = order.Created,
                Updated = order.Updated,
                Status = order.Status.ToString(),
                DeliveryMethod = order.DeliveryMethod.ToString(),
                CancelReason = order.CancelReason,
                OrderPrice = order.Items.Sum(r => r.UnitPrice * r.Quantity),
                Items = order.Items.Select(item => new OrderItemResponse
                {
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Category = item.Product.Category,
                }).ToList()
            }).ToList();

            return response;
        }
    }
}
