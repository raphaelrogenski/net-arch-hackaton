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

            builder.Property(r => r.Status)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(r => r.Notes)
                .HasColumnType("varchar(255)");

            builder.Property(r => r.IdOrder)
                .IsRequired();

            builder.Property(r => r.IdHandledBy)
                .IsRequired();

            builder.HasOne(r => r.Order)
                .WithMany()
                .HasForeignKey(r => r.IdOrder)
                .HasConstraintName("FK_KitchenOrders_Orders")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.HandledBy)
                .WithMany()
                .HasForeignKey(r => r.IdHandledBy)
                .HasConstraintName("FK_KitchenOrders_Users")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}