using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Data.ProcDatabase.ResultSets;
using ProcApi.DTOs.Base;
using ProcApi.Utility;

namespace ProcApi.Repositories.Abstracts;

public interface IMaterialRepository : IGenericRepository<Material>
{
    Task<Paginator<Material>> GetAllPaginated(PaginationRequestDto dto);
    Task<Material?> FindByCodeAndNameExceptCurrent(int id, string name, string code);
    Task<Material?> FindByCodeOrName(string name, string code);
    Task<IEnumerable<MaterialResultSet>> GetWithCategories(int id);
}