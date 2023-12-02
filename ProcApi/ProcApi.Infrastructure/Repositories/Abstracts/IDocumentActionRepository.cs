using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentActionRepository : IGenericRepository<DocumentAction>
{
    Task<bool> ExistsByDocIdAndAssignerId(int docId, int userId);
    Task<bool> ExistsByDocIdAndAssignerIdOrHasDelegation(int docId, int userId);
    Task<IEnumerable<DocumentAction>> GetByDocIdAsync(int docId);
}