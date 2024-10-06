using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentActionRepository : IGenericRepository<DocumentAction, int>
{
    Task<bool> ExistsByDocIdAndAssignerId(int docId, int userId);
    Task<bool> ExistsByDocIdAndAssignerIdOrHasDelegation(int docId, int userId);
    Task<IEnumerable<DocumentAction?>> GetByDocIdAsync(int docId);
    Task<DocumentAction?> GetByDocumentIdAndRole(int documentId, Roles role);
    Task<bool> HasByDocumentIdAndRoleAndUserId(int documentId, int userId, Roles role);
}