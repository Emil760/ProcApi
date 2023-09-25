using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IReleaseStrategyRepository : IGenericRepository<ReleaseStrategy>
{
    Task<ReleaseStrategy?> GetWithFlowTemplateAsync(DocumentStatus status, ActionType actionType);
    Task<int> GetCurrentRoleForApproveAsync(DocumentStatus status, ActionType actionType);
    Task<int> GetCurrentRoleForApproveAsync(int docId, ActionType actionType);
}