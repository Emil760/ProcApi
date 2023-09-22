using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Exceptions;
using ValidationException = ProcApi.Exceptions.ValidationException;

namespace ProcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TempController : BaseController
    {
        private readonly ILogger<TempController> _logger;

        public TempController(ILogger<TempController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTemp()
        {
            return Ok();
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

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}