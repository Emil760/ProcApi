using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Documents;
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

        [HttpPost("perform-action")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformDto dto)
        {
            await _purchaseRequestDocumentApprovalService.PerformAction(dto);
            return Ok();
        }
    }
}
