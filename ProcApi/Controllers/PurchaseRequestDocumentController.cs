using Microsoft.AspNetCore.Mvc;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("pr")]
    public class PurchaseRequestDocumentController : BaseController
    {
        private readonly IDocumentService _documentService;
        private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;
        private readonly IPurchaseRequestDocumentItemsService _purchaseRequestDocumentItemsService;
        private readonly IPurchaseRequestDocumentApprovalService _purchaseRequestDocumentApprovalService;

        public PurchaseRequestDocumentController(IPurchaseRequestDocumentService purchaseRequestDocumentService,
            IPurchaseRequestDocumentApprovalService purchaseRequestDocumentApprovalService,
            IPurchaseRequestDocumentItemsService purchaseRequestDocumentItemsService,
            IDocumentService documentService)
        {
            _purchaseRequestDocumentService = purchaseRequestDocumentService;
            _purchaseRequestDocumentApprovalService = purchaseRequestDocumentApprovalService;
            _purchaseRequestDocumentItemsService = purchaseRequestDocumentItemsService;
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocumentAsync([FromQuery] int docId)
        {
            return Ok(await _purchaseRequestDocumentService.GetDocument(docId));
        }

        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument()
        {
            return Ok(await _documentService.CreateDocumentWithApprovals(UserInfo,
                DocumentType.PurchaseRequest,
                DocumentStatus.PurchaseRequestDraft));
        }

        [HttpPost("create")]
        public async Task<IActionResult> SaveAsync([FromBody] CreatePRRequestDto dto)
        {
            return Ok(await _purchaseRequestDocumentService.CreateDocument(dto));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdatePRRequestDto dto)
        {
            return Ok(await _purchaseRequestDocumentService.UpdateDocument(dto));
        }

        [HttpPost("perform-action")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
        {
            await _purchaseRequestDocumentApprovalService.PerformAction(requestDto, UserInfo);
            return Ok();
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetItems([FromQuery] int docId)
        {
            return Ok(await _purchaseRequestDocumentItemsService.GetAllItemsAsync(docId));
        }
    }
}