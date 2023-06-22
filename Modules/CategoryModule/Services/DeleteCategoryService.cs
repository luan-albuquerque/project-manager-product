using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Services
{
    public class DeleteCategoryService
    {

        private readonly CategoryRepository _categoryRepository;
        public DeleteCategoryService(CategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }
    }
}
