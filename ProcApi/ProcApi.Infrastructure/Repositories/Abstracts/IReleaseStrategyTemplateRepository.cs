using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IReleaseStrategyTemplateRepository : IGenericRepository<ReleaseStrategyTemplate>
{
    Task<ReleaseStrategyTemplate?> GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
        string configuration, DocumentStatus status, ActionType action);
}