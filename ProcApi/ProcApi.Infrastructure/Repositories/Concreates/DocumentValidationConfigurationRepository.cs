using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class DocumentValidationConfigurationRepository : GenericRepository<DocumentValidationConfiguration>,
    IDocumentValidationConfigurationRepository

{
    public DocumentValidationConfigurationRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<DocumentValidationConfiguration>> GetActiveByTypeAndStatusAsync(
        DocumentType type,
        DocumentStatus status)
    {
        return await _context.DocumentValidationConfigurations
            .Where(dvc => dvc.DocumentTypeId == type
                          && dvc.DocumentStatusId == status
                          && dvc.IsEnabled)
            .ToListAsync();
    }
}