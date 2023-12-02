using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentActionRepository : GenericRepository<DocumentAction>, IDocumentActionRepository
{
    public DocumentActionRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByDocIdAndAssignerId(int docId, int userId)
    {
        return await _context.DocumentActions
            .Where(da => da.DocumentId == docId && da.AssignerId == userId)
            .AnyAsync();
    }

    public async Task<bool> ExistsByDocIdAndAssignerIdOrHasDelegation(int docId, int userId)
    {
        var actions = _context.DocumentActions.Where(da => da.DocumentId == docId);

        var delegations = _context.Delegations
            .Any(d => d.ToUserId == userId
                      && actions.Select(da => da.AssignerId)
                          .Contains(d.FromUserId)
                      && d.EndDate > DateTime.Now.Date);

        return await actions.AnyAsync(da => da.AssignerId == userId || delegations);
    }

    public async Task<IEnumerable<DocumentAction>> GetByDocIdAsync(int docId)
    {
        return await _context.DocumentActions
            .Where(da => da.DocumentId == docId)
            .ToListAsync();
    }
}