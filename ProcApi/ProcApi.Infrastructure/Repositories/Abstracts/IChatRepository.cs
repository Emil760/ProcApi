using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IChatRepository : IGenericRepository<Chat, int>
{
    Task<Chat?> FindWithChatUsersByAllUserIdsAsync(IEnumerable<int> userIds);
    Task<Chat?> FindWithChatUsersExceptCurrUserByChatIdAsync(int chatId, int userId);
}