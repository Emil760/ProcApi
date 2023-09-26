using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByIdCompiled(int id);
        Task<User?> FindWithRolesById(int id);
        Task<string?> ExistsByLogin(string login);
        Task<User?> FindWithPasswordHashByLogin(string login);
        Task<IEnumerable<string>> GetPermissions(int id);
        Task<IEnumerable<int>> GetRoles(int id);
        Task<User?> GetWithRoles(int id);
        Task<IEnumerable<User>> GetAllAsync(IEnumerable<int> userIds);
        Task<Paginator<User>> GetAllPaginated(PaginationModel dto);
    }
}