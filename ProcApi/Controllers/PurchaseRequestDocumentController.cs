using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Attributes;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Enums;
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

        //TODO
        //[HasPermission(Permissions.CanCreatePurchaseRequestDocument)]
        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument()
        {
            return Ok(await _documentService.CreateDocumentWithApprovals(UserInfo,
                DocumentType.PurchaseRequest,
                DocumentStatus.PurchaseRequestDraft));
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] CreatePurchaseRequestDocumentRequestDto dto)
        {
            return Ok();
        }

        [HttpPost("perform-action")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformRequestDto requestDto)
        {
            await _purchaseRequestDocumentApprovalService.PerformAction(requestDto);
            return Ok();
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetItems([FromQuery] int docId)
        {
            return Ok(await _purchaseRequestDocumentItemsService.GetAllItemsAsync(docId));
        }
    }
}