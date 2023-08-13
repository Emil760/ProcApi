using Microsoft.AspNetCore.Mvc;
using ProcApi.Attributes;
using ProcApi.DTOs.User;
using ProcApi.Enums;
using ProcApi.Services.Abstracts;

namespace ProcApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public UserController(IUserService userService, IFileService fileService)
        {
            _userService = userService;
            _fileService = fileService;
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