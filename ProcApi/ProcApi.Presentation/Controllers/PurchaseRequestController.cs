using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.Handlers.Document;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Application.Services.Concreates;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;
using ProcApi.Presentation.Filters;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseRequestController : BaseController
{
    private readonly IPurchaseRequestService _purchaseRequestService;
    private readonly IPurchaseRequestItemsService _purchaseRequestItemsService;
    private readonly IPurchaseRequestApprovalService _purchaseRequestApprovalService;
    private readonly IDocumentValidatorHandler _documentValidatorHandler;

    public PurchaseRequestController(IPurchaseRequestService purchaseRequestService,
        IPurchaseRequestApprovalService purchaseRequestApprovalService,
        IPurchaseRequestItemsService purchaseRequestItemsService,
        IDocumentValidatorHandler documentValidatorHandler)
    {
        _purchaseRequestService = purchaseRequestService;
        _purchaseRequestApprovalService = purchaseRequestApprovalService;
        _purchaseRequestItemsService = purchaseRequestItemsService;
        _documentValidatorHandler = documentValidatorHandler;
    }

    [HttpGet]
    [DocumentAccessFilter(new[]
    {
        Permissions.CanViewAll,
        Permissions.CanReturnPurchaseRequest,
        Permissions.CanRejectPurchaseRequest
    })]
    [HasPermission(Permissions.CanViewPurchaseRequest)]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestService.GetDocumentAsync(docId));
    }

    [HttpPost("Create")]
    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _purchaseRequestService.CreatePurchaseRequest(UserInfo));
    }

    [HttpPost("Save")]
    [HasPermission(Permissions.CanCreatePurchaseRequest)]
    public async Task<IActionResult> SaveAsync([FromBody] SavePRRequest dto)
    {
        return Ok(await _purchaseRequestService.SavePurchaseRequest(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequest request)
    {
        await _documentValidatorHandler.ValidateDocumentAsync(request.DocId, typeof(PurchaseRequestValidator));
        await _purchaseRequestApprovalService.PerformAction(request, UserInfo);
        return Ok();
    }

    [HttpGet("Items")]
    [HasPermission(Permissions.CanViewPurchaseRequest)]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestItemsService.GetAllItemsAsync(docId));
    }

    [HttpPut("AssignBuyer")]
    [HasPermission(Permissions.CanAssignBuyer)]
    public async Task<IActionResult> AssignBuyerToItemAsync([FromBody] AssignUserToItemRequest request)
    {
        await _purchaseRequestService.AssignBuyerToItemAsync(request);
        return Ok();
    }
}