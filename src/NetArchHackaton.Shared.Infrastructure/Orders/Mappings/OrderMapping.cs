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

            builder.Property(r => r.Status)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(r => r.DeliveryMethod)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(r => r.CancelReason)
                .HasColumnType("varchar(255)");

            builder.Property(r => r.IdCustomer)
                .IsRequired();

            builder.HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.IdCustomer)
                .HasConstraintName("FK_Orders_Users")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}