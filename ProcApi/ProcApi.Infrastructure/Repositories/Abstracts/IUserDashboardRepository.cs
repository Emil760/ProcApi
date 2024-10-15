using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IUserDashboardRepository : IGenericRepository<UserDashboard, int>
{
    Task<IEnumerable<UserDashboard>> GetByUserIdAsync(int userId);
    Task<UserDashboard?> GetWithSectionsAsync(int id);
}