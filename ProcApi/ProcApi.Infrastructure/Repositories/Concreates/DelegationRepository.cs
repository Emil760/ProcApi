using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DelegationRepository : GenericRepository<Delegation, int>, IDelegationRepository
{
    public DelegationRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Paginator<Delegation>> GetAllPaginated(PaginationModel pagination)
    {
        var query = _context.Delegations
            .Include(d => d.FromUser)
            .Include(d => d.ToUser)
            .Where(u => u.FromUser.FirstName.Contains(pagination.Search)
                        || u.ToUser.FirstName.Contains(pagination.Search))
            .AsQueryable();

        return await Paginator<Delegation>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }
}