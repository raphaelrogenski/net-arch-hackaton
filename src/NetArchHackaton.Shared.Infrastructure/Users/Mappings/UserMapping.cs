using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Infrastructure.Users
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "auth");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Created)
                .IsRequired();

            builder.Property(r => r.Updated);
        }
    }
}
