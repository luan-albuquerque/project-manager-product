using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.ProductModule.Services
{
    public class UpdateProductService
    {
        ProductRepository _productRepository;
        CategoryRepository _categoryRepository;

        public UpdateProductService(
            ProductRepository productRepository,
            CategoryRepository categoryRepository
            ) {
            _productRepository = productRepository;    
            _categoryRepository = categoryRepository;
        }


        public async Task Execute(string id, IUpdateProductDTO updateProductDTO) {
            var findOneProuct = await _productRepository.FindOne(id); 
            if (findOneProuct == null)
            {
                throw new ErrorException("Product  not found", 404);
            }

            var findOneCategory = await _categoryRepository.FinOne(updateProductDTO.categoryid);
            if (findOneCategory == null)
            {
                throw new ErrorException("Category  not found", 404);
            }


            findOneProuct.description = updateProductDTO.Description;
            findOneProuct.name = updateProductDTO.Name;
            findOneProuct.price_product = updateProductDTO.Price_product;
            findOneProuct.categoryid = updateProductDTO.categoryid;

            await _productRepository.Update(findOneProuct);


        }
        


    }
}
