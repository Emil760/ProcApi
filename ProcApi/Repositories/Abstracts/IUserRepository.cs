using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.Utility;

namespace ProcApi.Repositories.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByIdCompiled(int id);
        Task<string?> ExistsByLogin(string login);
        Task<User?> FindWithPasswordHashByLogin(string login);
        Task<IEnumerable<string>> GetPermissions(int id);
        Task<User?> GetWithRoles(int id);
        Task<Paginator<User>> GetAllPaginated(PaginationRequestDto dto);
    }
}