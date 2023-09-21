using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<Document?> GetWithActions(int docId);
}