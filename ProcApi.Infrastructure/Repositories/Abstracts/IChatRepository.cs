using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IChatRepository : IGenericRepository<Chat>
{
    Task<Chat?> FindWithChatUsersByAllUserIdsAsync(IEnumerable<int> userIds);
    Task<Chat?> FindWithChatUsersExceptCurrUserByChatIdAsync(int chatId, int userId);
}