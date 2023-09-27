using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class InvoiceDocumentService : IInvoiceDocumentService
{
    private readonly IInvoiceDocumentRepository _invoiceDocumentRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public InvoiceDocumentService(IInvoiceDocumentRepository invoiceDocumentRepository,
        IStringLocalizer<SharedResource> localizer)
    {
        _invoiceDocumentRepository = invoiceDocumentRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<UnusedPurchaseRequestItemsResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model)
    {
        return await _invoiceDocumentRepository.GetUnusedPurchaseRequestItemsAsync(model);
    }
}