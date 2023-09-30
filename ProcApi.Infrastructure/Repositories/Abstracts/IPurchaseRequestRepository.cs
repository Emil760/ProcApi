using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IPurchaseRequestRepository : IGenericRepository<PurchaseRequest>
{
    Task<PurchaseRequest?> GetWithDocumentAndItemsByDocId(int docId);
    Task<PurchaseRequest?> GetWithDocumentAndActionsAndItemsByDocId(int docId);
}