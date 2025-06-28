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
            await SeedProductsAsync(db);
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

        private static async Task SeedProductsAsync(AppDbContext dbContext)
        {
            var productsSet = dbContext.Set<Product>();

            if (productsSet.Any())
            {
                return;
            }

            var product01 = CreateProduct("Cheeseburger", "Pão, hambúrguer 120g, queijo e ketchup.", 14.90m, "Lanche", true);
            var product02 = CreateProduct("Chicken Crispy", "Frango empanado no pão brioche com maionese temperada.", 19.90m, "Lanche", false);
            var product03 = CreateProduct("Double Bacon", "Dois hambúrgueres, bacon crocante e queijo cheddar.", 21.90m, "Lanche", true);
            var product04 = CreateProduct("Veggie Delight", "Hambúrguer vegetal com alface, tomate e maionese vegana.", 18.50m, "Lanche", true);

            var product05 = CreateProduct("Batata Frita Média", "Porção média de batata frita crocante.", 8.90m, "Acompanhamento", true);
            var product06 = CreateProduct("Nuggets de Frango (6 unid.)", "Porção com 6 unidades de nuggets de frango crocantes.", 10.90m, "Acompanhamento", false);
            var product07 = CreateProduct("Onion Rings", "Anéis de cebola empanados e fritos.", 9.50m, "Acompanhamento", true);

            var product08 = CreateProduct("Brownie com Sorvete", "Brownie quente servido com uma bola de sorvete.", 10.50m, "Sobremesa", true);
            var product09 = CreateProduct("Sundae de Morango", "Sorvete de baunilha com calda de morango.", 7.90m, "Sobremesa", true);

            var product10 = CreateProduct("Milkshake Chocolate", "Milkshake cremoso de chocolate (300ml).", 9.90m, "Bebida", false);
            var product11 = CreateProduct("Refrigerante Lata", "Coca-Cola, Guaraná ou Fanta (350ml).", 5.50m, "Bebida", true);
            var product12 = CreateProduct("Suco Natural", "Suco de laranja ou limão espremido na hora.", 6.90m, "Bebida", true);

            productsSet.Add(product01);
            productsSet.Add(product02);
            productsSet.Add(product03);
            productsSet.Add(product04);
            productsSet.Add(product05);
            productsSet.Add(product06);
            productsSet.Add(product07);
            productsSet.Add(product08);
            productsSet.Add(product09);
            productsSet.Add(product10);
            productsSet.Add(product11);
            productsSet.Add(product12);

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

        private static Product CreateProduct(string name, string description, decimal price, string category, bool isAvailable)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                IsAvailable = isAvailable,
            };

            return product;
        }

    }
}
