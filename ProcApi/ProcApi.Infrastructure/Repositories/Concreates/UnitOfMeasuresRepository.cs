using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class UnitOfMeasuresRepository : GenericRepository<UnitOfMeasure>, IUnitOfMeasureRepository
{
    public UnitOfMeasuresRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UnitOfMeasure?>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await _context.UnitOfMeasures
            .Where(uom => ids.Contains(uom.Id))
            .ToListAsync();
    }

    public async Task<IEnumerable<UnitOfMeasure?>> GetAllActiveAsync()
    {
        return await _context.UnitOfMeasures
            .Where(uom => uom.IsActive)
            .ToListAsync();
    }

    public Task<bool> ExistsAll(params int[] ids)
    {
        return _context.UnitOfMeasures
            .AllAsync(uofc => ids.Contains(uofc.Id));
    }

    public Task<bool> ExistsByName(string name)
    {
        return _context.UnitOfMeasures
            .AnyAsync(ufm => ufm.Name == name);
    }

    public async Task<UnitOfMeasure?> GetRulesAsync(int id)
    {
        return await _context.UnitOfMeasures
            .Include(uom => uom.Converters)
            .ThenInclude(c => c.TargetUnitOfMeasure)
            .SingleOrDefaultAsync(uom => uom.Id == id);
    }
}