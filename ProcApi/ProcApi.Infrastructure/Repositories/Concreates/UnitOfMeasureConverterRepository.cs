using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class UnitOfMeasureConverterRepository : GenericRepository<UnitOfMeasureConverter, int>,
    IUnitOfMeasureConverterRepository
{
    public UnitOfMeasureConverterRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsBySourceAndTargetId(int sourceId, int targetId)
    {
        return await _context.UnitOfMeasureConverters
            .AnyAsync(uofc => uofc.SourceUnitOfMeasureId == sourceId
                              && uofc.TargetUnitOfMeasureId == targetId);
    }

    public async Task<UnitOfMeasureConverter?> GetBySourceIdAndTargetId(int sourceId, int targetId)
    {
        return await _context.UnitOfMeasureConverters
            .SingleOrDefaultAsync(uofc => uofc.SourceUnitOfMeasureId == sourceId
                                          && uofc.TargetUnitOfMeasureId == targetId);
    }
}