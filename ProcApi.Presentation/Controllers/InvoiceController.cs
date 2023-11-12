using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.DTOs.Invoice.Requests;
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
    private readonly IDocumentService _documentService;
    private readonly IInvoiceService _invoiceService;
    private readonly InvoiceApprovalService _invoiceApprovalService;

    public InvoiceController(IDocumentService documentService,
        IInvoiceService invoiceService,
        InvoiceApprovalService invoiceApprovalService)
    {
        _documentService = documentService;
        _invoiceService = invoiceService;
        _invoiceApprovalService = invoiceApprovalService;
    }

    [DocumentAccessFilter(new[] { Permissions.CanReturnInvoice, Permissions.CanRejectInvoice })]
    [HasPermission(Permissions.CanViewInvoice)]
    [HttpGet]
    public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
    {
        return Ok(await _invoiceService.GetDocumentAsync(docId));
    }

    [HasPermission(Permissions.CanCreateInvoice)]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _documentService.CreateDocumentWithApprovalsAsync(UserInfo,
            DocumentType.Invoice,
            DocumentStatus.InvoiceDraft));
    }

    [HasPermission(Permissions.CanCreateInvoice)]
    [HttpPost("Save")]
    public async Task<IActionResult> SaveAsync([FromBody] SaveInvoiceRequestDto dto)
    {
        return Ok(await _invoiceService.SaveInvoiceAsync(dto));
    }

    [HttpPost("PerformAction")]
    public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
    {
        await _invoiceApprovalService.PerformAction(requestDto, UserInfo);
        return Ok();
    }

    [HasPermission(Permissions.CanViewInvoice)]
    [HttpGet("UnusedPurchaseRequestItems")]
    public async Task<IActionResult> GetUnusedPurchaseRequestItemsAsync(PaginationModel model)
    {
        return Ok(await _invoiceService.GetUnusedPurchaseRequestItemsAsync(model));
    }
}