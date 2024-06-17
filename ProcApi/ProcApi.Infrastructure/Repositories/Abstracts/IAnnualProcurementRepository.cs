using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IAnnualProcurementRepository : IGenericRepository<AnnualProcurement>
{
    Task<bool> ExistsByYear(short year);
}