using Microsoft.EntityFrameworkCore;
using System.Data;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.UserModule.Entity;

namespace TesteVagaDevPleno.Infra
{
    public class ConnectionContext: DbContext
    {

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=25432; Database=test123;" +
                "User Id=root;" +
                "Password=123456;"
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                id = Guid.NewGuid().ToString(),
                name = "bugas",
                email = "bugas@gmail.com",
                password = BCrypt.Net.BCrypt.HashPassword("bugas123"),
                is_enabled = true,

        });
        }




        }
}
