using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Application.Services.Abstracts;

public interface IInvoiceDocumentService
{
    Task<IEnumerable<UnusedPurchaseRequestItemsResultSet>> GetUnusedPurchaseRequestItemsAsync(PaginationModel model);
}