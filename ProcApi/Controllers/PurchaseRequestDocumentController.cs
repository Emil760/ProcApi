using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.PurchaseRequestDocument;
using ProcApi.DTOs.User;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("pr")]
    [ApiController]
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

        [HttpPost("perform-action")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformDto dto)
        {
            await _purchaseRequestDocumentApprovalService.PerformAction(dto);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetDocucment()
        {
            return Ok();
        }

        // [HasPermission(Permissions.CanCreatePurchaseRequestDocument)]
        [AllowAnonymous]
        [HttpPost("create-document")]
        public async Task<IActionResult> CreateDocument([FromBody] CreatePurchaseRequestDocumentDto dto)
        {
            UserInfoDro = new UserInfoDro(15, "az");
            return Ok(await _purchaseRequestDocumentApprovalService.CreateDocument(UserInfoDro, dto));
        }
    }
}