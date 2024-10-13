using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class DashboardSectionRepository : GenericRepository<DashboardSection, int>, IDashboardSectionRepository
    {
        public DashboardSectionRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DashboardSection>> GetByDashboardIdAsync(int userDashboardId)
        {
            return await _context.DashboardSections
                .Where(x => x.UserDashboardId == userDashboardId)
                .ToListAsync();
        }
    }
}
