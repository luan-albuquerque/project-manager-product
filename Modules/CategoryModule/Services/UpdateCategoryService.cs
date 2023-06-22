using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Services
{
    public class UpdateCategoryService
    {

        private readonly CategoryRepository _categoryRepository;

        public UpdateCategoryService(CategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }
    }
}
