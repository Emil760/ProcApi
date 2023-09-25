﻿using ProcApi.DTOs.Documents.Requests;
using ProcApi.Services.Abstracts;

namespace ProcApi.Handlers.PurchaseRequestDocument;

public class PurchaseRequestReturnHandler : IActionHandler
{
    private readonly IApprovalsService _approvalsService;

    public PurchaseRequestReturnHandler(IApprovalsService approvalsService)
    {
        _approvalsService = approvalsService;
    }

    public async Task PerformAction(ActionPerformRequestDto dto, int userId)
    {
        await _approvalsService.CanPerformAction(dto, userId);

        await _approvalsService.ReturnDocumentAsync(dto);
    }
}