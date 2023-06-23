using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.ProductModule.Dtos;
using TesteVagaDevPleno.Modules.ProductModule.Entity;

namespace TesteVagaDevPleno.Modules.CategoryModule.Repository.contract
{
    public abstract class CategoryRepository
    {
        public abstract Task Create(ICreateCategoryDTO createCategoryDTO);
        public abstract Task<List<Category>> FindAll(IQueryCategoryRequest? query);
        public abstract Task<Category> FinOne(string id);
        public abstract Task Update(Category category);

    }
}
