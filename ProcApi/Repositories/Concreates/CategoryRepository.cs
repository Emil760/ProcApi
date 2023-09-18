using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Data.ProcDatabase.ResultSets;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

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