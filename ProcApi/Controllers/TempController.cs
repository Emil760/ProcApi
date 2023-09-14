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
            var tasks = new List<Task>();
            var task1 = Te1();
            var task2 = Te2();
            
            tasks.Add(task1);
            tasks.Add(task2);

            await Task.WhenAll(tasks);

            var a = task1.Result;
            var b = task2.Result;

            return Ok(a + "\t" + b);
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