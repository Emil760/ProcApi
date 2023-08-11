using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Controllers;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : BaseController
    {
        private readonly IUserService userService;

        public TempController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTemp()
        {
            return Ok("");
        }

        [HttpGet("Test2")]
        public IActionResult GetTemp2()
        {
            var a = HttpContext.Request.Cookies["cook2"];
            return Ok(a);
        }

        [HttpGet("Test3")]
        public async Task<IActionResult> GetTemp3()
        {
            var res = await userService.GetUsersAsync();
            return Ok(res);
        }
    }
}