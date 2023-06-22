
using Microsoft.EntityFrameworkCore;
using TesteVagaDevPleno.Infra;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Repository.implementations
{
    public class ProductRepositoryInEntity : ProductRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();
     

        public override async Task Create(ICreateProductDTO createProductDTO)
        {
             
            await _context.Products.AddAsync(new Product(createProductDTO.Name, createProductDTO.Description, createProductDTO.Price_product, createProductDTO.categoryid));

            _context.SaveChanges();
        }

        public override async Task<List<Product>> FindAll(IQueryProductRequest? query)
        {
            return await _context.Products
                .Where(p => p.name.Contains(query.Name ?? ""))
                .Where(p => p.description.Contains(query.Description ?? ""))
                .Skip(query.Skip ?? 0)
                .Take(query.Take ?? 10)
                .ToListAsync();
                
        }
    }
}
