using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IReleaseStrategyRepository : IGenericRepository<ReleaseStrategy>
{
    Task<ReleaseStrategy?> GetWithFlowTemplate(DocumentStatus status, ActionType actionType);
}