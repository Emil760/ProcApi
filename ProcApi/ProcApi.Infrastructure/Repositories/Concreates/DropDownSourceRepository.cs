using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DropDownSourceRepository : GenericRepository<DropDownSource, int>, IDropDownSourceRepository
{
    public DropDownSourceRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByKey(string key)
    {
        return await _context.DropDownSources
            .AnyAsync(dds => dds.Key == key);
    }

    public async Task<bool> ExistsByKeyNotThis(int id, string key)
    {
        return await _context.DropDownSources
            .AnyAsync(dds => dds.Id != id && dds.Key == key);
    }
}