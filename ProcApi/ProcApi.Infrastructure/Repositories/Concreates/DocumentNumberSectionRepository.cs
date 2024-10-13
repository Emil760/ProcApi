using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentNumberSectionRepository : GenericRepository<DocumentNumberSection, int>, IDocumentNumberSectionRepository
{
    public DocumentNumberSectionRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DocumentNumberSection>> GetActiveSectionsByTypeAsync(DocumentType documentType)
    {
        return await _context.DocumentNumberSections
            .Where(x => x.DocumentNumberPattern.DocumentType == documentType
                   && x.DocumentNumberPattern.IsActive)
            .OrderBy(x => x.Order)
            .ToListAsync();
    }

    public async Task<IEnumerable<DocumentNumberSection>> GetByDocumentNumberPatterIdAsync(int documentNumberPatternId)
    {
        return await _context.DocumentNumberSections
            .Where(x => x.DocumentNumberPatternId == documentNumberPatternId)
            .ToListAsync();
    }
}