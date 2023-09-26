using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IReleaseStrategyRepository : IGenericRepository<ReleaseStrategy>
{
    Task<ReleaseStrategy?> GetWithFlowTemplateAsync(DocumentStatus status, ActionType actionType);
    Task<int> GetCurrentRoleForApproveAsync(DocumentStatus status, ActionType actionType);
    Task<int> GetCurrentRoleForApproveAsync(int docId, ActionType actionType);
}