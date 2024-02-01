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

    [DocumentAccessFilter(new[]
    {
        Permissions.CanViewAll,
        Permissions.CanReturnPurchaseRequest,
        Permissions.CanRejectPurchaseRequest
    })]
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
        return Ok(await _purchaseRequestService.CreatePurchaseRequest(UserInfo));
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
        await _documentValidatorHandler.ValidateDocumentAsync(requestDto.DocId, typeof(PurchaseRequestValidator));
        await _purchaseRequestApprovalService.PerformAction(requestDto, UserInfo);
        return Ok();
    }

    [HasPermission(Permissions.CanViewPurchaseRequest)]
    [HttpGet("Items")]
    public async Task<IActionResult> GetItems([FromQuery] int docId)
    {
        return Ok(await _purchaseRequestItemsService.GetAllItemsAsync(docId));
    }

    [HasPermission(Permissions.CanAssignBuyer)]
    [HttpPut("AssignBuyer")]
    public async Task<IActionResult> AssignBuyerToItemAsync([FromBody] AssignUserToItemDto dto)
    {
        await _purchaseRequestService.AssignBuyerToItemAsync(dto);
        return Ok();
    }
}