using NetArchHackaton.Shared.Application.Orders.Exceptions;
using NetArchHackaton.Shared.Contracts.Orders.DTOs;
using NetArchHackaton.Shared.Domain.Orders;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetArchHackaton.Shared.Application.Orders.Validators
{
    public class OnCreateOrderValidator
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly IUserRepository userRepository;

        public OnCreateOrderValidator(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }

        internal void EnsureValidation(string userEmail, CreateOrderRequest request)
        {
            var enumerableItems = request.Items.Select(r => new KeyValuePair<Guid, int>(r.Id, r.Quantity));
            EnsureValidation(userEmail, request.GetDeliveryMethod(), enumerableItems);
        }

        internal void EnsureValidation(string userEmail, OrderDeliveryMethodEnum deliveryMethod, IEnumerable<KeyValuePair<Guid, int>> items)
        {
            var user = userRepository.Query(false).SingleOrDefault(r => r.Email == userEmail);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (deliveryMethod == OrderDeliveryMethodEnum.Unknown)
            {
                throw new OrderInvalidDeliveryMethodException();
            }

            if (items == null || !items.Any())
            {
                throw new OrderEmptyItemsException();
            }

            if (items.Any(r => r.Value == 0))
            {
                throw new OrderEmptyItemsException(); // REPLACE
            }

            var requestItemIds = items.Select(r => r.Key).Distinct();
            if (requestItemIds.Count() != items.Count())
            {
                throw new OrderDuplicatedItemsException();
            }

            var products = productRepository.Query(false).Where(r => requestItemIds.Contains(r.Id)).ToList();
            if (products.Count() != items.Count())
            {
                throw new OrderItemsNotFoundException();
            }

            if (products.Any(r => !r.IsAvailable))
            {
                throw new OrderItemsNotAvailableException();
            }
        }
    }
}
