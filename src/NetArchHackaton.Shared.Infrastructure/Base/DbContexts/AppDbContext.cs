using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace NetArchHackaton.Shared.Infrastructure.Base.DbContexts
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappings = GetType().Assembly.GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                .Where(type => type.GetInterfaces().Any((x) => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .Select(type => type)
                .ToList();

            foreach (var mapping in mappings)
            {
                dynamic map = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(map);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
