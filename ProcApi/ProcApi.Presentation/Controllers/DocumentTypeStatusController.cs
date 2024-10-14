using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.DocumentTypeStatus.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentTypeStatusController : BaseController
{
    private readonly IDocumentTypeStatusService _documentTypeStatusService;

    public DocumentTypeStatusController(IDocumentTypeStatusService documentTypeStatusService)
    {
        _documentTypeStatusService = documentTypeStatusService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddDocumentTypeStatusRequest dto)
    {
        return Ok(await _documentTypeStatusService.AddAsync(dto));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _documentTypeStatusService.GetAllAsync());
    }

    [HttpGet("AllByType")]
    public async Task<IActionResult> GetAllByTypeAsync(DocumentType documentType)
    {
        return Ok(await _documentTypeStatusService.GetAllByDocumentTypeAsync(documentType));
    }
}