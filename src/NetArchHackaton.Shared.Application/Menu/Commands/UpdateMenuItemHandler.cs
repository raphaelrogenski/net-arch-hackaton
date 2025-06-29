using NetArchHackaton.Shared.Application.Menu.Exceptions;
using NetArchHackaton.Shared.Contracts.Menu.Commands;
using NetArchHackaton.Shared.Contracts.Menu.DTOs;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Application.Menu.Commands
{
    public class UpdateMenuItemHandler : IUpdateMenuItemHandler
    {
        private readonly IProductRepository productRepository;

        public UpdateMenuItemHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> HandleAsync(Guid id, CommandMenuItemRequest request)
        {
            var product = productRepository.Query().SingleOrDefault(r => r.Id == id);
            if (product == null)
            {
                throw new MenuItemNotFoundException();
            }

            var exists = productRepository.Query(false).Any(r => r.Name == request.Name);
            if (exists)
            {
                throw new MenuItemNameAlreadyExistsException();
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Category = request.Category;
            product.IsAvailable = request.IsAvailable;

            productRepository.Update(product);

            return true;
        }
    }
}
