using NetArchHackaton.Shared.Application.Menu.Exceptions;
using NetArchHackaton.Shared.Contracts.Menu.DTOs;
using NetArchHackaton.Shared.Contracts.Menu.Queries;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Application.Menu.Queries
{
    public class GetMenuItemHandler : IGetMenuItemHandler
    {
        private readonly IProductRepository productRepository;

        public GetMenuItemHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<QueryMenuItemResponse> HandleAsync(Guid id)
        {
            var product = productRepository.Query().SingleOrDefault(r => r.Id == id);
            if (product == null)
            {
                throw new MenuItemNotFoundException();
            }

            var response = new QueryMenuItemResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                IsAvailable = product.IsAvailable
            };

            return response;
        }
    }
}
