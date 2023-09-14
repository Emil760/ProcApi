using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<IEnumerable<Group>> GetAllWithLastMessageByUserId(int userId);
}