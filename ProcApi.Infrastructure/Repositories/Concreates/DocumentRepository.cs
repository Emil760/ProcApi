using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Document?> GetWithActionsAsync(int docId)
    {
        return await _context.Documents
            .Include(d => d.Actions)
            .SingleOrDefaultAsync(d => d.Id == docId);
    }

    public async Task<DocumentStatus> GetStatus(int docId)
    {
        return await _context.Documents
            .Where(doc => doc.Id == docId)
            .Select(doc => doc.StatusId)
            .SingleOrDefaultAsync();
    }
}