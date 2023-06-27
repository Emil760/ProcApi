﻿using Microsoft.AspNetCore.Mvc;
using ProcApi.Services.Abstracts;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        private IUserService userService;

        public TempController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("Test")]
        public IActionResult GetTemp()
        {
            var a = HttpContext.Request.Cookies["cook2"];
            return Ok(a);
        }

        [HttpGet("Test2")]
        public async Task<IActionResult> GetTemp2()
        {
            var res = await userService.GetUsers();
            return Ok(res);
        }
    }
}
