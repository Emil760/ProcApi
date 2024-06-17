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

    public async Task<bool> ExistsByYear(short year)
    {
        return await _context.AnnualProcurements
            .AnyAsync(ap => ap.Year == year);
    }
}