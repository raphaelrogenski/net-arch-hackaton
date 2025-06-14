using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetArchHackaton.Shared.Domain.Orders;

namespace NetArchHackaton.Shared.Infrastructure.Orders
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Updated);
        }
    }
}