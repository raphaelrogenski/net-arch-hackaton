using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Contracts.Orders.Queries;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Application.Orders.Queries
{
    public class GetOrderByIdHandler : IGetOrderByIdHandler
    {
        private readonly IOrderRepository orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<OrderResponse> HandleAsync(string userEmail, Guid id)
        {
            var order = orderRepository.GetOrderDetails(userEmail, id);
            if (order == null)
            {
                throw new OrderNotFoundException();
            }

            var response = new OrderResponse
            {
                Id = order.Id,
                Created = order.Created,
                Updated = order.Updated,
                Status = order.Status.ToString(),
                DeliveryMethod = order.DeliveryMethod.ToString(),
                CancelReason = order.CancelReason,
                OrderPrice = order.Items?.Sum(r => r.UnitPrice * r.Quantity) ?? 0,
                Items = order.Items?.Select(item => new OrderItemResponse
                {
                    Name = item.Product.Name,
                    Description = item.Product.Description,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Category = item.Product.Category,
                })?.ToList()
            };

            return response;
        }
    }
}
