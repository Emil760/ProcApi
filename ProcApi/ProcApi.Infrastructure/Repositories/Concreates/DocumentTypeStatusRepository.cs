using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentTypeStatusRepository : GenericRepository<DocumentTypeStatus, int>, IDocumentTypeStatusRepository
{
    public DocumentTypeStatusRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistsByTypeAndStatus(DocumentType documentType, DocumentStatus documentStatus)
    {
        return await _context.DocumentTypeStatuses
            .AnyAsync(x => x.DocumentType == documentType && x.DocumentStatus == documentStatus);
    }

    public async Task<IEnumerable<DocumentTypeStatus>> GetAllByType(DocumentType documentType)
    {
        return await _context.DocumentTypeStatuses
            .Where(x => x.DocumentType == documentType)
            .ToListAsync();
    }
}