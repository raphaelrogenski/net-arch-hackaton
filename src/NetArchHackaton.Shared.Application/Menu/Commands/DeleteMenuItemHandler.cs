using NetArchHackaton.Shared.Application.Menu.Exceptions;
using NetArchHackaton.Shared.Contracts.Menu.Commands;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Application.Menu.Commands
{
    public class DeleteMenuItemHandler : IDeleteMenuItemHandler
    {
        private readonly IProductRepository productRepository;

        public DeleteMenuItemHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> HandleAsync(Guid id)
        {
            var exists = productRepository.Query().Any(r => r.Id == id);
            if (!exists)
            {
                throw new MenuItemNotFoundException();
            }

            productRepository.Delete(id);

            return true;
        }
    }
}
