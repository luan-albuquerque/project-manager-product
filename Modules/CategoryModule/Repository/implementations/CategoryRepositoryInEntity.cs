using Microsoft.EntityFrameworkCore;
using TesteVagaDevPleno.Infra;
using TesteVagaDevPleno.Modules.CategoryModule.Dtos;
using TesteVagaDevPleno.Modules.CategoryModule.Entity;
using TesteVagaDevPleno.Modules.CategoryModule.Repository.contract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TesteVagaDevPleno.Modules.CategoryModule.Repository.implementations
{
    public class CategoryRepositoryInEntity : CategoryRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();
        public override async Task Create(ICreateCategoryDTO createCategoryDTO)
        {

            await _context.Categories.AddAsync(new Category {
                    description = createCategoryDTO.description
                });
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

        public override async Task<Category> FinOne(string id)
        {
            return await _context.Categories
               .Where(c => c.id == id )
               .FirstOrDefaultAsync();
        }

        public override async Task Update(string id, IUpdateCategoryDTO updateCategoryDTO)
        {
               _context.Categories
              .Update(
                new Category
                {
                    id = id,
                    description = updateCategoryDTO.description
                });
                _context.SaveChanges();
        }


    }
}
