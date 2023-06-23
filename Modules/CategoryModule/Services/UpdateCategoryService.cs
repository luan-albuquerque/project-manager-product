using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
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

        public async Task Execute(string id, IUpdateCategoryDTO updateCategoryDTO)
        {
            var findOne = await _categoryRepository.FinOne(id);
            if (findOne == null)
            {
                throw new ErrorException("Category  not found", 404);
            }
            findOne.description = updateCategoryDTO.description;
            await _categoryRepository.Update(findOne);

        }

    }
}
