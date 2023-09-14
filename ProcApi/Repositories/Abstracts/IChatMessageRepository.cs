using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts
{
    public interface IChatMessageRepository : IGenericRepository<ChatMessage>
    {
        Task<ChatMessage?> GetWithChatUsersExceptCurrentUserByIdAsync(int id, int userId);
    }
}