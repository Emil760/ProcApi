using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class AnnualProcurementItemRepository : GenericRepository<AnnualProcurementItem>, IAnnualProcurementItemRepository
{
    public AnnualProcurementItemRepository(ProcDbContext context) : base(context)
    {
    }
}