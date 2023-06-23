using System.Data;
using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
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

        public async Task<Category> Execute(string id)
        {
            var findOne = await _categoryRepository.FinOne(id);
            if (findOne == null)
            {
                throw new ErrorException("Category  not found", 404);
            }
            return findOne;

        }
    }
}
