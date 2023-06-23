using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
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

        public async Task Execute(string id)
        {
            var findOne = await _categoryRepository.FinOne(id);
            if (findOne == null)
            {
                throw new ErrorException("Category not found", 404);
            }

            await _categoryRepository.Remove(findOne);
    

        }
    }
}
