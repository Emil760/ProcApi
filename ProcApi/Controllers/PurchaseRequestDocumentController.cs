using Microsoft.AspNetCore.Mvc;
using ProcApi.DTOs.Documents;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("pr")]
    public class PurchaseRequestDocumentController : BaseController
    {
        private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;

        public PurchaseRequestDocumentController(IPurchaseRequestDocumentService purchaseRequestDocumentService)
        {
            _purchaseRequestDocumentService = purchaseRequestDocumentService;
        }

        [HttpPost("perform-action")]
        public async Task<IActionResult> PerformAction([FromBody] ActionPerformDto dto)
        {
            return Ok();
        }
    }
}
