using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Services
{
    public class FindOneCategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public FindOneCategoryService(CategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }
    }
}
