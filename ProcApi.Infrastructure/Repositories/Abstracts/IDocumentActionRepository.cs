using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentActionRepository : IGenericRepository<DocumentAction>
{
    Task<IEnumerable<DocumentAction>> GetByDocIdAsync(int docId);
}