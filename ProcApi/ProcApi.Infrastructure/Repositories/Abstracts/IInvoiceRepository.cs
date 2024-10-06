using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IInvoiceRepository : IGenericRepository<Invoice, int>
{
    Task<Invoice?> GetWithDocumentAndActionsAndItemsByDocId(int docId);
    Task<Invoice?> GetWithDocumentAndItemsByDocId(int docId);
    Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model);

    Task<IEnumerable<UnusedPRItemResultSet>> GetUnusedPurchaseRequestItemsByIdsAsync(int[] ids);
}