using NetArchHackaton.Shared.Application.Menu.Exceptions;
using NetArchHackaton.Shared.Contracts.Menu.Commands;
using NetArchHackaton.Shared.Contracts.Menu.DTOs;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Application.Menu.Commands
{
    public class CreateMenuItemHandler : ICreateMenuItemHandler
    {
        private readonly IProductRepository productRepository;

        public CreateMenuItemHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Guid> HandleAsync(CommandMenuItemRequest request)
        {
            var exists = productRepository.Query(false).Any(r => r.Name == request.Name);
            if (exists)
            {
                throw new MenuItemNameAlreadyExistsException();
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                IsAvailable = request.IsAvailable,
            };

            productRepository.Create(product);

            return product.Id;
        }
    }
}
