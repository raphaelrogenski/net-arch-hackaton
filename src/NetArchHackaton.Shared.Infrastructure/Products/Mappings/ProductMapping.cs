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

            builder.Property(r => r.Name)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(r => r.Description)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(r => r.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasMaxLength(11);

            builder.Property(r => r.Category)
                .IsRequired()
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(r => r.IsAvailable)
                .IsRequired();
        }
    }
}
