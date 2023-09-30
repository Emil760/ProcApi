using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentActionRepository : IGenericRepository<DocumentAction>
{
    Task<bool> ExistsByDocIdAndUserId(int docId, int userId);
    Task<IEnumerable<DocumentAction>> GetByDocIdAsync(int docId);
}