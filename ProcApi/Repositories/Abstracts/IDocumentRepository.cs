using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<Document?> GetWithActionsAsync(int docId);
    Task<DocumentStatus> GetStatus(int docId);
}