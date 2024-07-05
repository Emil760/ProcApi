using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Application.Handlers.PurchaseRequest;

public class PurchaseRequestRejectHandler : IActionHandler
{
    private readonly IApprovalsService _approvalsService;

    public PurchaseRequestRejectHandler(IApprovalsService approvalsService)
    {
        _approvalsService = approvalsService;
    }

    public async Task PerformAction(ActionPerformRequest dto, int userId)
    {
        await _approvalsService.CanPerformAction(dto, userId);

        await _approvalsService.RejectDocumentAsync(dto);
    }
}