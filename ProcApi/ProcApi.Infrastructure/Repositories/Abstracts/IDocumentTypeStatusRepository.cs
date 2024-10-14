using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IDocumentTypeStatusRepository : IGenericRepository<DocumentTypeStatus, int>
{
    Task<bool> ExistsByTypeAndStatus(DocumentType documentType, DocumentStatus documentStatus);
    Task<IEnumerable<DocumentTypeStatus>> GetAllByType(DocumentType documentType);
}