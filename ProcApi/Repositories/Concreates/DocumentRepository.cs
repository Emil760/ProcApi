using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Document?> GetWithActions(int docId)
    {
        return await _context.Documents
            .Include(d => d.DocumentActions)
            .SingleOrDefaultAsync(d => d.Id == docId);
    }
}