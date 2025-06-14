using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetArchHackaton.Shared.Domain.KitchenOrders;

namespace NetArchHackaton.Shared.Infrastructure.KitchenOrders
{
    public class KitchenOrderMapping : IEntityTypeConfiguration<KitchenOrder>
    {
        public void Configure(EntityTypeBuilder<KitchenOrder> builder)
        {
            builder.ToTable("KitchenOrders", "order");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Updated);
        }
    }
}