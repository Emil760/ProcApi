using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IChatRepository : IGenericRepository<Chat>
{
    Task<Chat?> FindWithChatUsersByAllUserIdsAsync(IEnumerable<int> userIds);
    Task<IEnumerable<Chat>> GetChatsByUserIdAsync(int userId);
}