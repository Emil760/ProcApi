using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDepartmentRepository : IGenericRepository<Department>
{
    Task<bool> ExistsByName(string name);
    Task<Paginator<Department>> GetAllPaginated(PaginationModel pagination);
}