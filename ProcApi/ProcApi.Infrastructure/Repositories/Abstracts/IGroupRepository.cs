using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<IEnumerable<Group>> GetAllWithLastMessageByUserId(int userId);
}