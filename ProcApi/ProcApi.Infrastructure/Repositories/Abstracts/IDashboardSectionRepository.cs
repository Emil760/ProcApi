using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts
{
    public interface IDashboardSectionRepository : IGenericRepository<DashboardSection, int>
    {
        Task<IEnumerable<DashboardSection>> GetByDashboardIdAsync(int userDashboardId);
        Task<IEnumerable<int>> GetIdsByDashboardIdAsync(int userDashboardId);
    }
}
