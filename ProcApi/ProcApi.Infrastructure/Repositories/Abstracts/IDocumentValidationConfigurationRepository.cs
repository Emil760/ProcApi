using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentValidationConfigurationRepository : IGenericRepository<DocumentValidationConfiguration, int>
{
    Task<IEnumerable<DocumentValidationConfiguration>> GetActiveByTypeAndStatusAsync(
        DocumentType type,
        DocumentStatus status);
}