using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.PurchaseRequestDocument;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.User;
using ProcApi.DTOs.User.Base;
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

        // [HasPermission(Permissions.CanCreatePurchaseRequestDocument)]
        [AllowAnonymous]
        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument([FromBody] CreatePurchaseRequestDocumentRequestDto requestDto)
        {
            UserInfo = new UserInfo(15, "az");
            return Ok(await _purchaseRequestDocumentApprovalService.CreateDocument(UserInfo, requestDto));
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