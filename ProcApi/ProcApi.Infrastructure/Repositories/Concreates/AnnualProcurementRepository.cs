using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class AnnualProcurementRepository : GenericRepository<AnnualProcurement>, IAnnualProcurementRepository
{
    public AnnualProcurementRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByYearAsync(short year)
    {
        return await _context.AnnualProcurements
            .AnyAsync(ap => ap.Year == year);
    }
    
    public async Task<bool> ExistsByYearAndActiveAsync(short year, bool isActive)
    {
        return await _context.AnnualProcurements
            .AnyAsync(ap => ap.Year == year && ap.IsActive == isActive);
    }

    public async Task<AnnualProcurement?> GetWithItemsByIdAsync(int id)
    {
        return await _context.AnnualProcurements
            .Include(ap => ap.Items)
            .SingleOrDefaultAsync(ap => ap.Id == id);
    }
}