using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
{
    Task<IEnumerable<InvoiceItem>> GetByDocId(int docId);

    Task<IEnumerable<InvoiceItem>> GetByPurchaseItemIdsAndStatus(
        IEnumerable<int> purchaseItemIds,
        DocumentStatus status);
}