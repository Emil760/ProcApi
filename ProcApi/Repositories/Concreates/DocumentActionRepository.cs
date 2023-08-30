using ProcApi.Data.ProcDatabase;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Repositories.Abstracts;

namespace ProcApi.Repositories.Concreates;

public class DocumentActionRepository : GenericRepository<DocumentAction>, IDocumentActionRepository
{
    public DocumentActionRepository(ProcDbContext context) : base(context)
    {
    }
}