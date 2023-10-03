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

    public async Task<bool> ExistsByDocIdAndUserId(int docId, int userId)
    {
        return await _context.DocumentActions
            .Where(da => da.DocumentId == docId && da.UserId == userId)
            .AnyAsync();
    }

    public async Task<IEnumerable<DocumentAction>> GetByDocIdAsync(int docId)
    {
        return await _context.DocumentActions.Where(da => da.DocumentId == docId).ToListAsync();
    }
}