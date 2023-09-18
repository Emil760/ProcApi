using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Data.ProcDatabase.ResultSets;

namespace ProcApi.Repositories.Abstracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> ExistsByNameAndParentCategoryId(int parentId, string name);
    Task<IEnumerable<CategoryResultSet>> GetCategoriesByLevel(int level);
}