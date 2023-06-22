using Microsoft.EntityFrameworkCore;
using TesteVagaDevPleno.Infra;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.CategoryModule.Repository.implementations
{
    public class CategoryRepositoryInEntity : CategoryRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();
        public override async Task Create(ICreateCategoryDTO createCategoryDTO)
        {

            await _context.Categories.AddAsync(new Category(
                     createCategoryDTO.description
                ));
           await _context.SaveChangesAsync();
        }

        public override async Task<List<Category>> FindAll(IQueryCategoryRequest? query)
        {
           return await _context.Categories
                .Where(c => c.description.Contains(query.Description ?? ""))
                .Skip(query.Skip ?? 0)
                .Take(query.Take ?? 0)
                .ToListAsync();
              
        }
    }
}
