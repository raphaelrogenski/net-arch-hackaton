using Microsoft.Extensions.DependencyInjection;
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

            var user1 = CreateCustomer("Customer A", "customer@a.com", "13961574928", "S3nhaF0rte!");
            var user2 = CreateCustomer("Customer B", "customer@b.com", "25835810903", "S3nhaF0rte!");
            var user3 = CreateEmployee("Manager", "manager@fasttech.com", "S3nhaF0rte!", UserRoleEnum.Manager);
            var user4 = CreateEmployee("Kitchen", "kitchen@fasttech.com", "S3nhaF0rte!", UserRoleEnum.Kitchen);

            usersSet.Add(user1);
            usersSet.Add(user2);
            usersSet.Add(user3);
            usersSet.Add(user4);

            dbContext.SaveChanges();
        }

        private static User CreateCustomer(string fullName, string email, string cpf, string password)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                FullName = fullName,
                Email = email,
                CPF = cpf,
                Role = UserRoleEnum.Customer,
            };

            user.PasswordHash = hasher.HashPassword(user, password);

            return user;
        }

        private static User CreateEmployee(string fullName, string email, string password, UserRoleEnum role)
        {
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                FullName = fullName,
                Email = email,
                Role = role,
            };

            user.PasswordHash = hasher.HashPassword(user, password);

            return user;
        }
    }
}
