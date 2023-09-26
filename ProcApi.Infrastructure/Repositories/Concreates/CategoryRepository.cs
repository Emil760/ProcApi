using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAndParentCategoryId(int parentId, string name)
        {
            return await _context.Categories
                .AnyAsync(c => c.ParentCategoryId == parentId && c.Name == name);
        }

        public async Task<IEnumerable<CategoryResultSet>> GetCategoriesByLevel(int level)
        {
            return await _context.GetCategoriesByLevel(level)
                .ToListAsync();
        }
    }
}