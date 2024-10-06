using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class DashboardRepository : GenericRepository<Dashboard, int>, IDashboardRepository
    {
        public DashboardRepository(ProcDbContext context) : base(context)
        {
        }
    }
}
