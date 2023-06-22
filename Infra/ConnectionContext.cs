using Microsoft.EntityFrameworkCore;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Entity;

namespace TesteVagaDevPleno.Infra
{
    public class ConnectionContext: DbContext
    {

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=25432; Database=test123;" +
                "User Id=root;" +
                "Password=123456;"
            );
      



    }
}
