using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IMaterialRepository : IGenericRepository<Material>
{
    Task<Paginator<Material>> GetAllPaginated(PaginationModel pagination);
    Task<Material?> FindByCodeAndNameExceptCurrent(int id, string name, string code);
    Task<Material?> FindByCodeOrName(string name, string code);
    Task<IEnumerable<MaterialResultSet>> GetWithCategories(int id);
}