using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Services
{
    public class FindOneProductService
    {
        ProductRepository _productRepository;


        public FindOneProductService(ProductRepository productRepository) {
            _productRepository = productRepository;    
        }


        public async Task<Product> Execute(string id) {
            var findOne = await _productRepository.FindOne(id); 
            if (findOne == null)
            {
                throw new ErrorException("Product  not found", 404);
            }
            return findOne;
        }
        


    }
}
