using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DropDownItemRepository : GenericRepository<DropDownItem>, IDropDownItemRepository
{
    public DropDownItemRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByKeyNotThis(int id, int sourceId, string value)
    {
        return await _context.DropDownItems
            .AnyAsync(ddi => ddi.DropDownSourceId == sourceId && ddi.Id != id && ddi.Value == value);
    }

    public async Task<bool> ExistsByKey(int sourceId, string value)
    {
        return await _context.DropDownItems
            .AnyAsync(ddi => ddi.DropDownSourceId == sourceId && ddi.Value == value);
    }
}