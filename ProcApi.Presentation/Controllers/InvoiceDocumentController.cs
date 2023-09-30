using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceDocumentController : BaseController
{
    private readonly IDocumentService _documentService;
    private readonly IInvoiceService _invoiceService;

    public InvoiceDocumentController(IDocumentService documentService,
        IInvoiceService invoiceService)
    {
        _documentService = documentService;
        _invoiceService = invoiceService;
    }
    
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

    [HttpGet("UnusedPurchaseRequestItems")]
    public async Task<IActionResult> GetUnusedPurchaseRequestItemsAsync(PaginationModel model)
    {
        return Ok(await _invoiceService.GetUnusedPurchaseRequestItemsAsync(model));
    }
}