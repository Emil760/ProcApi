using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Application.Handlers.Invoice;

public class InvoiceApproveHandler : IActionHandler
{
    private readonly IApprovalsService _approvalsService;

    public InvoiceApproveHandler(IApprovalsService approvalsService)
    {
        _approvalsService = approvalsService;
    }

    public async Task PerformAction(ActionPerformRequestDto dto, int userId)
    {
        await _approvalsService.CanPerformAction(dto, userId);

        await _approvalsService.ApproveDocumentAsync(dto, userId);
    }
}