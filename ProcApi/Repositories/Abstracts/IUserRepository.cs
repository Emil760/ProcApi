using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
