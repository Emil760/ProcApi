using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DocumentValidator;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.Handlers;
using ProcApi.Application.Handlers.Document;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;
using ProcApi.Presentation.Filters;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodReceiptNoteController : BaseController
{
    private readonly IGoodReceiptNoteService _goodReceiptNoteService;
    private readonly IDocumentValidatorHandler _validatorHandler;
    private readonly IApprovalCoordinator _approvalCoordinator;

    public GoodReceiptNoteController(IGoodReceiptNoteService goodReceiptNoteService,
        IApprovalCoordinator approvalCoordinator,
        IDocumentValidatorHandler validatorHandler)
    {
        _goodReceiptNoteService = goodReceiptNoteService;
        _approvalCoordinator = approvalCoordinator;
        _validatorHandler = validatorHandler;
    }

    [HttpGet]
    [DocumentAccessFilter(new[]
    {
        Permissions.CanViewAll,
        Permissions.CanReturnGoodReceiptNote,
        Permissions.CanRejectGoodReceiptNote
    })]
    [HasPermission(Permissions.CanViewGoodReceiptNote)]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _goodReceiptNoteService.GetDocumentAsync(docId));
    }

    [HttpPost("Create")]
    [HasPermission(Permissions.CanCreateGoodReceiptNote)]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _goodReceiptNoteService.CreateGoodReceiptNoteAsync(UserInfo));
    }

    [HttpPost("Save")]
    [HasPermission(Permissions.CanCreateGoodReceiptNote)]
    public async Task<IActionResult> SaveAsync([FromBody] SavePRRequest dto)
    {
        return Ok(await _goodReceiptNoteService.SaveGoodReceiptNoteAsync(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequest request)
    {
        await _validatorHandler.ValidateDocumentAsync(request.DocId, typeof(GoodReceiptValidator));
        await _approvalCoordinator.PerformAction(request, UserInfo);
        return Ok();
    }

    [HttpGet("Items")]
    [HasPermission(Permissions.CanViewGoodReceiptNote)]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _goodReceiptNoteService.GetAllItemsAsync(docId));
    }
}