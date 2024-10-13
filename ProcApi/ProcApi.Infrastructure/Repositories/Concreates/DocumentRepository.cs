using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentRepository : GenericRepository<Document, int>, IDocumentRepository
{
    public DocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<Document?> GetWithActionsAsync(int id)
    {
        return await _context.Documents
            .Include(d => d.Actions)
            .SingleOrDefaultAsync(d => d.Id == id);
    }

    public async Task<DocumentStatus?> GetStatusAsync(int docId)
    {
        return await _context.Documents
            .Where(doc => doc.Id == docId)
            .Select(doc => doc.DocumentStatusId)
            .SingleOrDefaultAsync();
    }

    public async Task<DocumentType?> GetTypeAsync(int id)
    {
        return await _context.Documents
            .Where(doc => doc.Id == id)
            .Select(doc => doc.DocumentTypeId)
            .SingleOrDefaultAsync();
    }

    public async Task<int> GetCountByTypeAsync(DocumentType documentType)
    {
        return await _context.Documents
            .Where(x => x.DocumentTypeId == documentType)
            .CountAsync();
    }

    public async Task<bool> HasByDocumentNumberPatternId(int documentNumberPatterId)
    {
        return await _context.Documents
            .Where(d => d.DocumentNumberPatternId == documentNumberPatterId)
            .AnyAsync();
    }
}