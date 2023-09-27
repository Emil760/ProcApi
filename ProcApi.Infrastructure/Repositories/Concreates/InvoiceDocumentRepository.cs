using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class InvoiceDocumentRepository : GenericRepository<InvoiceDocument>, IInvoiceDocumentRepository
{
    public InvoiceDocumentRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UnusedPurchaseRequestItemsResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model)
    {
        return await _context.GetUnusedPurchaseRequestItems(
                model.PageNumber,
                model.PageSize,
                "%" + model.Search + "%")
            .ToListAsync();
    }
}