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
public class PurchaseRequestController : BaseController
{
    private readonly IPurchaseRequestService _purchaseRequestService;
    private readonly IApprovalCoordinator _approvalCoordinator;
    private readonly IDocumentValidatorHandler _documentValidatorHandler;

    public PurchaseRequestController(IPurchaseRequestService purchaseRequestService,
        IApprovalCoordinator approvalCoordinator,
        IDocumentValidatorHandler documentValidatorHandler)
    {
        _purchaseRequestService = purchaseRequestService;
        _approvalCoordinator = approvalCoordinator;
        _documentValidatorHandler = documentValidatorHandler;
    }

    [HttpGet]
    [DocumentAccessFilter([
        Permissions.CanViewAll,
        Permissions.CanReturnPurchaseRequest,
        Permissions.CanRejectPurchaseRequest
    ])]
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
        await _approvalCoordinator.PerformAction(request, UserInfo);
        return Ok();
    }

    [HttpGet("Items")]
    [HasPermission(Permissions.CanViewPurchaseRequest)]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestService.GetAllItemsAsync(docId));
    }

    [HttpPut("AssignBuyer")]
    [HasPermission(Permissions.CanAssignBuyer)]
    public async Task<IActionResult> AssignBuyerToItemAsync([FromBody] AssignUserToItemRequest request)
    {
        await _purchaseRequestService.AssignBuyerToItemAsync(request);
        return Ok();
    }
}