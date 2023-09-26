using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IChatUserRepository : IGenericRepository<ChatUser>
{
    Task<bool> AllExistsByUserIdsAsync(IEnumerable<int> userIds);
    Task<IEnumerable<ChatUser>> GetAllWithLastMessageByUserIdAsync(int userId);
}