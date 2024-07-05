using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Application.Handlers.Invoice;

public class InvoiceSubmitHandler : IActionHandler
{
    private readonly IApprovalsService _approvalsService;
    private readonly IInvoiceService _invoiceService;

    public InvoiceSubmitHandler(IApprovalsService approvalsService,
        IInvoiceService invoiceService)
    {
        _approvalsService = approvalsService;
        _invoiceService = invoiceService;
    }

    public async Task PerformAction(ActionPerformRequest dto, int userId)
    {
        await _approvalsService.CanPerformAction(dto, userId);

        await _approvalsService.ApproveDocumentAsync(dto, userId);

        await _invoiceService.ChangePurchaseRequestItemStatuses(dto.DocId);
    }
}