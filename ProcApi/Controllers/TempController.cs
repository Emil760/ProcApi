using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProcApi.Controllers;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TempController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public TempController(IUserService userService,
            IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> GetTemp()
        {
            var aa = await _userRepository.GetWithRoles(9);
            return Ok(aa);
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
            var res = await _userService.GetUsersAsync();
            return Ok(res);
        }
    }
}