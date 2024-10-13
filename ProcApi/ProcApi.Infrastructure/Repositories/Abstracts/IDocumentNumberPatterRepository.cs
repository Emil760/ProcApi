using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentNumberPatterRepository : IGenericRepository<DocumentNumberPattern, int>
{
    Task<bool> HasActiveByDocumentTypeAsync(DocumentType documentType);
    Task<DocumentNumberPattern?> GetActiveByDocumentType(DocumentType documentType);
}