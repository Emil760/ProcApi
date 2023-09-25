using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Repositories.Abstracts;

public interface IDocumentActionRepository : IGenericRepository<DocumentAction>
{
    Task<IEnumerable<DocumentAction>> GetByDocId(int docId);
}