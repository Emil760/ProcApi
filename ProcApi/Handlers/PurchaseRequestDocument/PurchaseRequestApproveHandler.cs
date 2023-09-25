using ProcApi.DTOs.Documents.Requests;
using ProcApi.Services.Abstracts;

namespace ProcApi.Handlers.PurchaseRequestDocument;

public class PurchaseRequestApproveHandler : IActionHandler
{
    private readonly IApprovalsService _approvalsService;

    public PurchaseRequestApproveHandler(IApprovalsService approvalsService)
    {
        _approvalsService = approvalsService;
    }

    public async Task PerformAction(ActionPerformRequestDto dto, int userId)
    {
        await _approvalsService.CanPerformAction(dto, userId);

        await _approvalsService.ApproveDocumentAsync(dto, userId);
    }
}