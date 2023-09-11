using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts
{
    public interface IChatMessageRepository : IGenericRepository<ChatMessage>
    {
        Task<ChatMessage?> GetWithChatUsersByIdAsync(int id);
    }
}