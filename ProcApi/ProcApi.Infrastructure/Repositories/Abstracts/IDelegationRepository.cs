using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDelegationRepository : IGenericRepository<Delegation>
{
    Task<Paginator<Delegation>> GetAllPaginated(PaginationModel pagination);
}