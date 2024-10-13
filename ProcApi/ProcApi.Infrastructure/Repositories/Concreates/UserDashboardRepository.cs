using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class UserDashboardRepository : GenericRepository<UserDashboard, int>, IUserDashboardRepository
    {
        public UserDashboardRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserDashboard>> GetByUserIdAsync(int userId)
        {
            return await _context.UserDashboards
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<UserDashboard?> GetWithSectionsAsync(int id)
        {
            return await _context.UserDashboards
                .Include(x => x.Sections)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
