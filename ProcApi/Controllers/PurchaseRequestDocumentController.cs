using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Attributes;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Enums;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("pr")]
    public class PurchaseRequestDocumentController : BaseController
    {
        private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;
        private readonly IPurchaseRequestDocumentApprovalService _purchaseRequestDocumentApprovalService;

        public PurchaseRequestDocumentController(IPurchaseRequestDocumentService purchaseRequestDocumentService,
            IPurchaseRequestDocumentApprovalService purchaseRequestDocumentApprovalService)
        {
            _purchaseRequestDocumentService = purchaseRequestDocumentService;
            _purchaseRequestDocumentApprovalService = purchaseRequestDocumentApprovalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocucment()
        {
            return Ok();
        }

        [HasPermission(Permissions.CanCreatePurchaseRequestDocument)]
        [AllowAnonymous]
        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument([FromBody] CreatePurchaseRequestDocumentRequestDto requestDto)
        {
            return Ok(await _purchaseRequestDocumentService.CreateDocument(UserInfo, requestDto));
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
            return Ok();
        }
    }
}