using ProcApi.Domain.Entities;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<bool> ExistsByNameAndParentCategoryId(int parentId, string name);
    Task<IEnumerable<CategoryResultSet>> GetCategoriesByLevel(int level);
}