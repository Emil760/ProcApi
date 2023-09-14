using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IChatRepository : IGenericRepository<Chat>
{
    Task<Chat?> FindWithChatUsersByAllUserIdsAsync(IEnumerable<int> userIds);
    Task<Chat?> FindWithChatUsersExceptCurrUserByChatIdAsync(int chatId, int userId);
}