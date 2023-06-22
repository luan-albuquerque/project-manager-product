using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Services
{
    public class CreateProductService
    {
        private readonly ProductRepository _productRepository;

        public CreateProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute(ICreateProductDTO createProductDTO)
        {

            await _productRepository.Create(createProductDTO);
        }
    }
}
