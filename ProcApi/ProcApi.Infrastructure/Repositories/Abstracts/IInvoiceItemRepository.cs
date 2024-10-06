using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem, int>
{
    Task<IEnumerable<InvoiceItem>> GetByDocIdAsync(int docId);

    Task<InvoiceItem?> GetWithUnitOfMeasureByIdAsync(int id);

    Task<IEnumerable<InvoiceItem>> GetByPurchaseItemIdsAndStatus(
        IEnumerable<int> purchaseItemIds,
        DocumentStatus status);
}