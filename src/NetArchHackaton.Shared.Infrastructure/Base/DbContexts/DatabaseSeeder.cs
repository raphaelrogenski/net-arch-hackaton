using Microsoft.Extensions.DependencyInjection;
using NetArchHackaton.Shared.Domain.Products;
using NetArchHackaton.Shared.Domain.Users;

namespace NetArchHackaton.Shared.Infrastructure.Base.DbContexts
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await SeedUsersAsync(db);
        }

        private static async Task SeedUsersAsync(AppDbContext dbContext)
        {
            var usersSet = dbContext.Set<User>();

            if (usersSet.Any())
            {
                return;
            }

            usersSet.Add(CreateUser("Customer", "", "11111111111", "S3nhaF0rte!", "Customer"));
            usersSet.Add(CreateUser("Manager", "manager@fasttech.com", "", "S3nhaF0rte!", "Manager"));

            dbContext.SaveChanges();
        }

        private static User CreateUser(string fullName, string email, string cpf, string password, string role)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                FullName = fullName,
                Email = email,
                CPF = cpf,
                Role = role,
            };

            user.PasswordHash = hasher.HashPassword(user, password);

            return user;
        }
    }
}
