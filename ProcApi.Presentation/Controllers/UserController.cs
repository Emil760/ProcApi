using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserCachedService _userCachedService;

        public UserController(IUserService userService,
            IUserCachedService userCachedService)
        {
            _userService = userService;
            _userCachedService = userCachedService;
        }

        [HasPermission(Permissions.CanViewUser)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HasPermission(Permissions.CanViewUser)]
        [HttpGet("GetCached")]
        public async Task<IActionResult> GetCachedAsync(int userId)
        {
            return Ok(await _userCachedService.GetByIdAsync(userId));
        }

        [HasPermission(Permissions.CanCreateUser)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserDto dto)
        {
            return Ok(await _userService.AddUserAsync(dto));
        }
    }
}