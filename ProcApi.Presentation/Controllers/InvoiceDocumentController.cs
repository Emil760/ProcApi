using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Application.Services.Concreates;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceDocumentController : BaseController
{
    private readonly DocumentService _documentService;
    private readonly IInvoiceDocumentService _invoiceDocumentService;

    public InvoiceDocumentController(DocumentService documentService,
        IInvoiceDocumentService invoiceDocumentService)
    {
        _documentService = documentService;
        _invoiceDocumentService = invoiceDocumentService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateDocumentAsync()
    {
        return Ok(await _documentService.CreateDocumentWithApprovalsAsync(UserInfo,
            DocumentType.Invoice,
            DocumentStatus.InvoiceDraft));
    }

    // [HttpPost("Save")]
    // public async Task<IActionResult> SaveAsync([FromBody] CreatePRRequestDto dto)
    // {
    //     return Ok(await _invoiceDocumentService.CreateDocument(dto));
    // }
    //
    // [HttpPost("Update")]
    // public async Task<IActionResult> UpdateAsync([FromBody] UpdatePRRequestDto dto)
    // {
    //     return Ok(await _invoiceDocumentService.UpdateDocument(dto));
    // }

    [HttpGet("UnusedPurchaseRequestItems")]
    public async Task<IActionResult> GetUnusedPurchaseRequestItemsAsync(PaginationModel model)
    {
        return Ok(await _invoiceDocumentService.GetUnusedPurchaseRequestItemsAsync(model));
    }
}