using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class InvoiceItemRepository : GenericRepository<InvoiceItem, int>, IInvoiceItemRepository
{
    public InvoiceItemRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<InvoiceItem>> GetByDocIdAsync(int docId)
    {
        return await _context.InvoiceItems
            .Where(idi => idi.InvoiceId == docId)
            .ToListAsync();
    }

    public async Task<InvoiceItem?> GetWithUnitOfMeasureByIdAsync(int id)
    {
        return await _context.InvoiceItems
            .Include(i => i.UnitOfMeasure)
            .SingleOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<InvoiceItem>> GetByPurchaseItemIdsAndStatus(
        IEnumerable<int> purchaseItemIds,
        DocumentStatus status)
    {
        return await _context.InvoiceItems
            .Where(idi => purchaseItemIds.Contains(idi.PurchaseRequestItemId)
                          && idi.Invoice.Document.DocumentStatusId == status)
            .ToListAsync();
    }
}