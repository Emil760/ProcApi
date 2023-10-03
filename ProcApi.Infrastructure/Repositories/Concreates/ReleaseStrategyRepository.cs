﻿using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class ReleaseStrategyRepository : GenericRepository<ReleaseStrategy>, IReleaseStrategyRepository
{
    public ReleaseStrategyRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<ReleaseStrategy?> GetWithFlowTemplateAsync(DocumentStatus status, ActionType actionType)
    {
        return await _context.ReleaseStrategies
            .Include(rs => rs.ApprovalFlowTemplate)
            .SingleOrDefaultAsync(rs => rs.ActiveStatusId == status && rs.ActionTypeId == actionType);
    }

    public async Task<int> GetCurrentRoleForApproveAsync(DocumentStatus status, ActionType actionType)
    {
        return await _context.ReleaseStrategies
            .Where(rs => rs.ActiveStatusId == status && rs.ActionTypeId == actionType)
            .Select(r => r.ApprovalFlowTemplate.RoleId)
            .SingleOrDefaultAsync();
    }

    public async Task<int> GetCurrentRoleForApproveAsync(int docId, ActionType actionType)
    {
        var status = _context.Documents.Where(d => d.Id == docId).Select(d => d.StatusId).Single();

        return await _context.ReleaseStrategies
            .Where(rs => rs.ActiveStatusId == status && rs.ActionTypeId == actionType)
            .Select(r => r.ApprovalFlowTemplate.RoleId)
            .SingleOrDefaultAsync();
    }
}