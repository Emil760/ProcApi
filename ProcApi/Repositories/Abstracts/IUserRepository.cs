using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByIdCompiled(int id);
    }
}
