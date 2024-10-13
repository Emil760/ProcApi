using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentNumberPatternRepository : GenericRepository<DocumentNumberPattern, int>, IDocumentNumberPatterRepository
{
    public DocumentNumberPatternRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<DocumentNumberPattern?> GetActiveByDocumentType(DocumentType documentType)
    {
        return await _context.DocumentNumberPatterns
            .Where(x => x.IsActive && x.DocumentType == documentType)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> HasActiveByDocumentTypeAsync(DocumentType documentType)
    {
        return await _context.DocumentNumberPatterns
            .Where(x => x.DocumentType == documentType && x.IsActive)
            .AnyAsync();
    }

}