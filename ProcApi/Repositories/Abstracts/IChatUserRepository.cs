using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IChatUserRepository : IGenericRepository<ChatUser>
{
    Task<bool> AllExistsByUserIds(IEnumerable<int> userIds);
}