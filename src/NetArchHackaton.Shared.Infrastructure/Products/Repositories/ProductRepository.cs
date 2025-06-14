using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Repositories;

namespace NetArchHackaton.Shared.Infrastructure.Products
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
