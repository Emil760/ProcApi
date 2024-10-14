using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Dashboard.Requests;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDashboardController : BaseController
    {
        private readonly IUserDashboardService _userDashboardService;

        public UserDashboardController(IUserDashboardService userDashboardService)
        {
            _userDashboardService = userDashboardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDashboardAsync([FromBody] AddDashboardRequest dto)
        {
            return Ok(await _userDashboardService.CreateDashboardAsync(UserInfo.UserId, dto));
        }

        [HttpGet("MyDashboards")]
        public async Task<IActionResult> GetAllByUserIdAsync()
        {
            return Ok(await _userDashboardService.GetAllByUserIdAsync(UserInfo.UserId));
        }

        [HttpGet("SelectedSections")]
        public async Task<IActionResult> GetSelectedSectionsAsync([FromQuery] int userDashboardId)
        {
            return Ok(await _userDashboardService.GetSelectedSectionsAsync(userDashboardId));
        }

        [HttpPost("ManageSection")]
        public async Task<IActionResult> ManageSectionAsync([FromBody] ManageSectionRequest dto)
        {
            await _userDashboardService.ManageSectionAsync(dto);
            return Ok();
        }
    }
}
