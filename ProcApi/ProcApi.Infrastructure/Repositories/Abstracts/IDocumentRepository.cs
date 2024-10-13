using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentRepository : IGenericRepository<Document, int>
{
    Task<Document?> GetWithActionsAsync(int id);
    Task<DocumentStatus?> GetStatusAsync(int id);
    Task<DocumentType?> GetTypeAsync(int id);
    Task<int> GetCountByTypeAsync(DocumentType documentType);
    Task<bool> HasByDocumentNumberPatternId(int documentNumberPatterId);
}