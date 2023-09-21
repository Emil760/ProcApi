using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class ReleaseStrategyRepository : GenericRepository<ReleaseStrategy>, IReleaseStrategyRepository
{
    public ReleaseStrategyRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<ReleaseStrategy?> GetWithFlowTemplate(DocumentStatus status, ActionType actionType)
    {
        return await _context.ReleaseStrategies
            .Include(rs => rs.ApprovalFlowTemplate)
            .SingleOrDefaultAsync(rs => rs.ActiveStatusId == status && rs.ActionTypeId == actionType);
    }
}