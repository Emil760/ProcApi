using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ValidationException = ProcApi.Domain.Exceptions.ValidationException;

namespace ProcApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TempController : BaseController
    {
        private readonly ILogger<TempController> _logger;
        private readonly IDocumentRepository _documentRepository;

        public TempController(ILogger<TempController> logger, IDocumentRepository documentRepository)
        {
            _logger = logger;
            _documentRepository = documentRepository;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTemp()
        {
            return Ok(await _documentRepository.GetStatus(4));
        }

        [HttpGet("Test2")]
        public IActionResult GetTemp2()
        {
            throw new UnauthorizedException("a2");
            return Ok();
        }

        [HttpGet("Test3")]
        public async Task<IActionResult> GetTemp3()
        {
            throw new ValidationException("a3");
            return Ok();
        }

        private async Task<int> Te1()
        {
            await Task.Delay(100);
            return 100;
        }

        private async Task<string> Te2()
        {
            await Task.Delay(200);
            return "hello";
        }
    }
}