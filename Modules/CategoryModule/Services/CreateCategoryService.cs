using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Services
{
    public class CreateCategoryService
    {

        private readonly CategoryRepository _categoryRepository;
        public CreateCategoryService(CategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;
        }

        public async Task execute(ICreateCategoryDTO createCategoryDTO)
        {
            await _categoryRepository.Create(createCategoryDTO);

        }
    }
}
