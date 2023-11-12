using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;
using ProcApi.Presentation.Filters;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseRequestController : BaseController
{
    private readonly IDocumentService _documentService;
    private readonly IPurchaseRequestService _purchaseRequestService;
    private readonly IPurchaseRequestItemsService _purchaseRequestItemsService;
    private readonly IPurchaseRequestApprovalService _purchaseRequestApprovalService;

    public PurchaseRequestController(IPurchaseRequestService purchaseRequestService,
        IPurchaseRequestApprovalService purchaseRequestApprovalService,
        IPurchaseRequestItemsService purchaseRequestItemsService,
        IDocumentService documentService)
    {
        _purchaseRequestService = purchaseRequestService;
        _purchaseRequestApprovalService = purchaseRequestApprovalService;
        _purchaseRequestItemsService = purchaseRequestItemsService;
        _documentService = documentService;
    }

    [DocumentAccessFilter(new[] { Permissions.CanReturnPurchaseRequest, Permissions.CanRejectPurchaseRequest })]
    [HasPermission(Permissions.CanViewPurchaseRequest)]
    [HttpGet]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestService.GetDocumentAsync(docId));
    }

    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _documentService.CreateDocumentWithApprovalsAsync(UserInfo,
            DocumentType.PurchaseRequest,
            DocumentStatus.PurchaseRequestDraft));
    }

    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    [HttpPost("Save")]
    public async Task<IActionResult> SaveAsync([FromBody] SavePRRequestDto dto)
    {
        return Ok(await _purchaseRequestService.SavePurchaseRequest(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
    {
        await _purchaseRequestApprovalService.PerformAction(requestDto, UserInfo);
        return Ok();
    }

    [HasPermission(Permissions.CanViewPurchaseRequest)]
    [HttpGet("ItemsDto")]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestItemsService.GetAllItemsAsync(docId));
    }
}