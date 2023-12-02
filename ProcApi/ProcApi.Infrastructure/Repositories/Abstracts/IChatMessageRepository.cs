using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IChatMessageRepository : IGenericRepository<ChatMessage>
{
    Task<ChatMessage?> GetWithChatUsersExceptCurrentUserByIdAsync(int id, int userId);
}