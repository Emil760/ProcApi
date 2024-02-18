using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.Handlers.Document;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Application.Services.Concreates;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Presentation.Attributes;
using ProcApi.Presentation.Filters;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : BaseController
{
    private readonly IInvoiceService _invoiceService;
    private readonly IInvoiceApprovalService _invoiceApprovalService;
    private readonly IDocumentValidatorHandler _documentValidatorHandler;
    private readonly IApprovalsService _approvalsService;

    public InvoiceController(IInvoiceService invoiceService,
        IInvoiceApprovalService invoiceApprovalService,
        IDocumentValidatorHandler documentValidatorHandler,
        IApprovalsService approvalsService)
    {
        _invoiceService = invoiceService;
        _invoiceApprovalService = invoiceApprovalService;
        _documentValidatorHandler = documentValidatorHandler;
        _approvalsService = approvalsService;
    }

    [HttpGet]
    [DocumentAccessFilter(new[]
    {
        Permissions.CanViewAll,
        Permissions.CanReturnInvoice,
        Permissions.CanRejectInvoice
    })]
    [HasPermission(Permissions.CanViewInvoice)]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _invoiceService.GetDocumentAsync(docId));
    }

    [HttpPost("Create")]
    [HasPermission(Permissions.CanCreateInvoice)]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _invoiceService.CreateInvoice(UserInfo));
    }

    [HttpPost("Save")]
    [HasPermission(Permissions.CanCreateInvoice)]
    public async Task<IActionResult> SaveAsync([FromBody] SaveInvoiceRequestDto dto)
    {
        return Ok(await _invoiceService.SaveInvoiceAsync(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
    {
        await _documentValidatorHandler.ValidateDocumentAsync(requestDto.DocId, typeof(InvoiceValidator));
        await _invoiceApprovalService.PerformAction(requestDto, UserInfo);
        return Ok();
    }

    [HttpGet("UnusedPurchaseRequestItems")]
    [HasPermission(Permissions.CanViewInvoice)]
    public async Task<IActionResult> GetUnusedPurchaseRequestItemsAsync([FromQuery] PaginationModel model)
    {
        return Ok(await _invoiceService.GetUnusedPurchaseRequestItemsAsync(model));
    }

    [HttpPost("AddReviewer")]
    [HasPermission(Permissions.CanChangeReviewer)]
    public async Task<IActionResult> AddReviewerAsync([FromBody] AddReviewerRequestDto dto)
    {
        await _approvalsService.AddApprovalToDocument(
            dto.DocumentId, dto.ReviewerId, Roles.Reviewer, DocumentType.Invoice);
        return Ok();
    }

    [HttpPut("RemoveReviewer")]
    [HasPermission(Permissions.CanChangeReviewer)]
    public async Task<IActionResult> RemoveReviewerAsync([FromQuery] RemoveReviewerRequestDto dto)
    {
        await _approvalsService.RemoveApprovalFromDocument(
            dto.DocumentId, dto.ReviewerId, Roles.Reviewer, DocumentType.Invoice);
        return Ok();
    }

    [HttpPut("ChangeUnitOfMeasureItem")]
    [HasPermission(Permissions.CanCreateInvoice)]
    public async Task<IActionResult> ChangeUnitOfMeasureItemAsync([FromBody] ChangeUnitOfMeasureItemDto dto)
    {
        await _invoiceService.ChangeUnitOfMeasureItem(dto);
        return Ok();
    }

    [HttpGet("Item")]
    [HasPermission(Permissions.CanViewInvoice)]
    public async Task<IActionResult> GetItem(int id)
    {
        return Ok(await _invoiceService.GetItemAsync(id));
    }
}