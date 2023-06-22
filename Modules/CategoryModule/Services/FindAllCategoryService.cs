using Microsoft.AspNetCore.Mvc;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Services
{
    public class FindAllCategoryService
    {

        private readonly CategoryRepository _categoryRepository;
        public FindAllCategoryService(CategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }

        public async Task<List<Category>> Execute(IQueryCategoryRequest query)
        {

            return await _categoryRepository.FindAll(query);

        }
    }
}
