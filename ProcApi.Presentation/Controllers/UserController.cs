using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HasPermission(Permissions.CanCreateUser)]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserDto dto)
        {
            return Ok(await _userService.AddUserAsync(dto));
        }
    }
}