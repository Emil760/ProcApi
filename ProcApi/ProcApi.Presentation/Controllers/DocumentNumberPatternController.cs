using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.DocumentPattern.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentNumberPatternController : BaseController
    {
        private readonly IDocumentNumberPatternService _documentNumberPatternService;

        public DocumentNumberPatternController(
            IDocumentNumberPatternService documentNumberPatternService)
        {
            _documentNumberPatternService = documentNumberPatternService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatternAsync(CreateDocumentNumberPatternRequest dto)
        {
            return Ok(await _documentNumberPatternService.CreatePatternAsync(dto));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetPatternsAsync()
        {
            return Ok(await _documentNumberPatternService.GetPatternsAsync());
        }

        [HttpPut("Activate")]
        public async Task<IActionResult> ActivatePatternAsync(ActivateDocumentNumberPatternRequest dto)
        {
            await _documentNumberPatternService.ActivatePatternAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ChnageDocumentNumberPatterAsync(ChangeDocumentNumberPatternRequest dto)
        {
            await _documentNumberPatternService.ChnageDocumentNumberPatterAsync(dto);
            return Ok();
        }

        [HttpPost("Section")]
        public async Task<IActionResult> AddSectionAsync(CreateDocumentNumberSectionRequest dto)
        {
            return Ok(await _documentNumberPatternService.AddSectionAsync(dto));
        }

        [HttpGet("Sections")]
        public async Task<IActionResult> GetSectionAsync(int documentDocumentPatterId)
        {
            return Ok(await _documentNumberPatternService.GetSectionAsync(documentDocumentPatterId));
        }
    }
}
