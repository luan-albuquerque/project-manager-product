using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;

namespace TesteVagaDevPleno.Modules.ProductModule.Repository.contract
{
    public abstract class ProductRepository
    {

        public abstract Task Create(ICreateProductDTO createProductDTO);
        public abstract Task<List<Product>> FindAll(IQueryProductRequest? query);
        public abstract Task<Product> FindOne(string id);

    }
}
