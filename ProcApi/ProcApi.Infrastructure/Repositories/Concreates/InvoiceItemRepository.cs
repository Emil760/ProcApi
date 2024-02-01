using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
{
    public InvoiceItemRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<InvoiceItem>> GetByDocId(int docId)
    {
        return await _context.InvoiceDocumentItems
            .Where(idi => idi.InvoiceId == docId)
            .ToListAsync();
    }

    public async Task<IEnumerable<InvoiceItem>> GetByPurchaseItemIdsAndStatus(
        IEnumerable<int> purchaseItemIds,
        DocumentStatus status)
    {
        return await _context.InvoiceDocumentItems
            .Where(idi => purchaseItemIds.Contains(idi.PurchaseRequestItemId)
                          && idi.Invoice.Document.DocumentStatusId == status)
            .ToListAsync();
    }
}