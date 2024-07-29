using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<Document?> GetWithActionsAsync(int id);
    Task<DocumentStatus?> GetStatusAsync(int id);
    Task<DocumentType?> GetTypeAsync(int id);
}