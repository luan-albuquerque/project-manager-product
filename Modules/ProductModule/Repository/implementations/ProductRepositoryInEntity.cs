
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

             await _context.Products.AddAsync(
                new Product {
                    name = createProductDTO.Name,
                    description = createProductDTO.Description,
                    price_product = createProductDTO.Price_product,
                    categoryid = createProductDTO.categoryid
                }
               );

            _context.SaveChanges();
        }

        public override async Task<List<Product>> FindAll(IQueryProductRequest? query)
        {


            return await _context.Products
                .Select(p => new Product {
                    
                    id = p.id, name = p.name, 
                    description = p.description,
                    price_product = p.price_product, 
                    categoryid = p.categoryid,
                    category = p.category
                 })
                .Where(p => p.name.Contains(query.Name ?? ""))
                .Where(p => p.description.Contains(query.Description ?? ""))
                .Skip(query.Skip ?? 0)
                .Take(query.Take ?? 10)
                .ToListAsync();
                
        }

        public override async Task<Product> FindOne(string id)
        {
            return await _context.Products
               .Select(p => new Product
                    {

                        id = p.id,
                        name = p.name,
                        description = p.description,
                        price_product = p.price_product,
                        categoryid = p.categoryid,
                        category = p.category
                    })
               .Where(p => p.id == id)
               .FirstAsync();
        }
    }
}
