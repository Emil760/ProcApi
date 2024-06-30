using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
{
    public MaterialRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Paginator<Material>> GetAllPaginated(PaginationModel pagination)
    {
        var query = _context.Materials
            .Include(m => m.Category)
            .Where(u => u.Name.Contains(pagination.Search) || u.Description.Contains(pagination.Search))
            .AsQueryable();

        return await Paginator<Material>.FromQuery(query, pagination.PageNumber, pagination.PageSize);
    }

    public async Task<IEnumerable<Material>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await _context.Materials
               .Where(m => ids.Contains(m.Id))
               .ToListAsync();
    }

    public async Task<bool> ExistsByCode(string code)
    {
        return await _context.Materials.AnyAsync(m => m.Code == code);
    }

    public async Task<bool> ExistsByCodeAndName(string name, string code)
    {
        return await _context.Materials.AnyAsync(m => m.Name == name
                                                      || m.Code == code);
    }

    public async Task<Material?> FindByCodeAndNameExceptCurrent(int id, string name, string code)
    {
        return await _context.Materials.SingleOrDefaultAsync(m => m.Id != id
                                                                  && (m.Name == name || m.Code == code));
    }

    public async Task<Material?> FindByCodeOrName(string name, string code)
    {
        return await _context.Materials.SingleOrDefaultAsync(m => m.Name == name
                                                                  || m.Code == code);
    }

    public async Task<IEnumerable<MaterialResultSet>> GetWithCategories(int id)
    {
        return await _context.GetMaterialWithCategories(id)
            .ToListAsync();
    }

}