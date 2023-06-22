using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Services
{
    public class FindAllProductService
    {
        ProductRepository _productRepository;


        public FindAllProductService(ProductRepository productRepository) {
            _productRepository = productRepository;    
        }


        public async Task<List<Product>> Execute(IQueryProductRequest query) {

            return await _productRepository.FindAll(query);
        }
        


    }
}
