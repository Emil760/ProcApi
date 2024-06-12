using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Presentation.Attributes;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : BaseController
    {
        private readonly IProjectSercive _projectSercive;

        public ProjectController(IProjectSercive projectSercive)
        {
            _projectSercive = projectSercive;
        }

        [HttpGet]
        [HasPermission(Permissions.CanViewProject)]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var project = await _projectSercive.GetProjectsAsync();
            return Ok(project);
        }

        [HttpGet("DropDown")]
        public async Task<IActionResult> GetProjectsForDropDownAsync()
        {
            var project = await _projectSercive.GetProjectsForDropDownAsync();
            return Ok(project);
        }

        [HttpPost]
        [HasPermission(Permissions.CanAddProject)]
        public async Task<IActionResult> CreateProjectAsync(CreateProjectRequestDto dto)
        {
            var project = await _projectSercive.CreateProjectAsync(dto);
            return Ok(project);
        }
    }
}
