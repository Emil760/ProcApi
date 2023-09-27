using ProcApi.Domain.Entities;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IInvoiceDocumentRepository : IGenericRepository<InvoiceDocument>
{
    Task<IEnumerable<UnusedPurchaseRequestItemsResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model);
}