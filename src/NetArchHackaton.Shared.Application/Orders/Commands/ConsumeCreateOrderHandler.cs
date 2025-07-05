using NetArchHackaton.Shared.Application.Auth;
using NetArchHackaton.Shared.Application.Auth.Exceptions;
using NetArchHackaton.Shared.Application.Base.Messaging;
using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.Commands;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.OrderItems;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Domain.Users;
namespace NetArchHackaton.Shared.Application.Orders.Commands
{
    public class ConsumeCreateOrderHandler : IConsumeCreateOrderHandler
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;

        public ConsumeCreateOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }

        public async Task<bool> HandleAsync(string customerEmail, CreateOrderRequest request)
        {
            var user = userRepository.Query(false).SingleOrDefault(r => r.Email == customerEmail);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var deliveryMethod = request.GetDeliveryMethod();
            if (deliveryMethod == OrderDeliveryMethodEnum.Unknown)
            {
                throw new OrderInvalidDeliveryMethodException();
            }

            if (request.Items == null || !request.Items.Any())
            {
                throw new OrderEmptyItemsException();
            }

            if (request.Items.Any(r => r.Quantity == 0))
            {
                throw new OrderEmptyItemsException(); // REPLACE
            }

            var requestItemIds = request.Items.Select(r => r.Id).Distinct();
            if (requestItemIds.Count() != request.Items.Count())
            {
                throw new OrderDuplicatedItemsException();
            }

            var products = productRepository.Query(false).Where(r => requestItemIds.Contains(r.Id)).ToList();
            if (products.Count() != request.Items.Count())
            {
                throw new OrderItemsNotFoundException();
            }

            if (products.Any(r => !r.IsAvailable))
            {
                throw new OrderItemsNotAvailableException();
            }

            var items = new List<OrderItem>();
            foreach (var requestItem in request.Items)
            {
                var product = products.SingleOrDefault(r => r.Id == requestItem.Id);

                var item = new OrderItem()
                {
                    Quantity = requestItem.Quantity,
                    UnitPrice = product.Price,
                    IdProduct = product.Id,
                };
                items.Add(item);
            }

            var order = new Order()
            {
                Status = OrderStatusEnum.Pending,
                DeliveryMethod = deliveryMethod,
                IdCustomer = user.Id,
                Items = items
            };

            orderRepository.Create(order);

            return true;
        }
    }
}
