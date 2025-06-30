using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetArchHackaton.Shared.Domain.OrderItems;

namespace NetArchHackaton.Shared.Infrastructure.OrderItems
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "order");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Updated);

            builder.Property(r => r.Quantity)
                .IsRequired();

            builder.Property(r => r.UnitPrice)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(r => r.IdOrder)
                .IsRequired();

            builder.Property(r => r.IdProduct)
                .IsRequired();

            builder.HasOne(r => r.Order)
                .WithMany(r => r.Items)
                .HasForeignKey(r => r.IdOrder)
                .HasConstraintName("FK_OrderItems_Orders")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.IdProduct)
                .HasConstraintName("FK_OrderItems_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}