using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByName(string name)
    {
        return await _context.Departments
            .Where(d => d.Name == name)
            .AnyAsync();
    }

    public async Task<Paginator<Department>> GetAllPaginated(PaginationModel pagination)
    {
        var query = _context.Departments
            .Include(d => d.HeadUser)
            .Where(u => u.Name.Contains(pagination.Search))
            .AsQueryable();

        return await Paginator<Department>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }
}