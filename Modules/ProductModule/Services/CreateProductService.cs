using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Services
{
    public class CreateProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public CreateProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Execute(ICreateProductDTO createProductDTO)
        {

            var findOneCategory = await _categoryRepository.FinOne(createProductDTO.categoryid);
            if (findOneCategory == null)
            {
                throw new ErrorException("Category  not found", 404);
            }

            await _productRepository.Create(createProductDTO);
        }
    }
}
