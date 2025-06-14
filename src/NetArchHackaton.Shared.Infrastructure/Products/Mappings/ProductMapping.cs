using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetArchHackaton.Shared.Domain.Products;

namespace NetArchHackaton.Shared.Infrastructure.Products
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "menu");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Updated);
        }
    }
}
