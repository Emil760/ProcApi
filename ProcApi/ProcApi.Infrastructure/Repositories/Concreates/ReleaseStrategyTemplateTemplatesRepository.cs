using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class ReleaseStrategyTemplateTemplatesRepository : GenericRepository<ReleaseStrategyTemplate>,
    IReleaseStrategyTemplateRepository
{
    public ReleaseStrategyTemplateTemplatesRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<ReleaseStrategyTemplate?> GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
        string configuration, DocumentStatus status, ActionType action)
    {
        return await _context.ReleaseStrategyTemplates
            .Include(rst => rst.ApprovalFlowTemplate)
            .Where(rst => rst.FlowCodes == configuration
                          && rst.ActiveStatusId == status
                          && rst.ActionTypeId == action)
            .SingleOrDefaultAsync();
    }
}