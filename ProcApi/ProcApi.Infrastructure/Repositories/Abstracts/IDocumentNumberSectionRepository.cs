using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentNumberSectionRepository : IGenericRepository<DocumentNumberSection, int>
{
    Task<IEnumerable<DocumentNumberSection>> GetActiveSectionsByTypeAsync(DocumentType documentType);
    Task<IEnumerable<DocumentNumberSection>> GetByDocumentNumberPatterIdAsync(int documentNumberPatternId);
}