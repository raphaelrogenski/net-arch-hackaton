using NetArchHackaton.Shared.Contracts.Menu;
using NetArchHackaton.Shared.Contracts.Menu.DTOs;
using NetArchHackaton.Shared.Contracts.Menu.Queries;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Application.Menu.Queries
{
    public class GetMenuHandler : IGetMenuHandler
    {
        private readonly IProductRepository productRepository;

        public GetMenuHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<MenuResponse> HandleAsync(MenuRequest request)
        {
            var query = productRepository.Query(false);

            if (!string.IsNullOrWhiteSpace(request.Category))
            {
                query = query.Where(r => r.Category == request.Category);
            }

            if (request.OnlyAvailable)
            {
                query = query.Where(r => r.IsAvailable);
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(r => r.Name.Contains(request.Search));
            }

            var response = new MenuResponse()
            {
                Items = query.ToList().Select(r => new QueryMenuItemResponse 
                { 
                    Id = r.Id,
                    Name = r.Name, 
                    Description = r.Description,
                    Price = r.Price,
                    Category = r.Category,
                    IsAvailable = r.IsAvailable,
                }).ToList()
            };

            return response;
        }
    }
}
