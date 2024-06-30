using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }


        [HttpGet("ForDropDown")]
        public async Task<IActionResult> GetDashboardsForDropDownAsync()
        {
            var result = await _dashboardService.GetAllForDropDownAsync();
            return Ok(result);
        }
    }
}
