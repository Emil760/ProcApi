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
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("All")]
        [HasPermission(Permissions.CanViewProject)]
        public async Task<IActionResult> GetProjectsAsync()
        {
            var project = await _projectService.GetProjectsAsync();
            return Ok(project);
        }
        
        [HttpGet]
        [HasPermission(Permissions.CanViewProject)]
        public async Task<IActionResult> GetProjectAsync(int id)
        {
            var project = await _projectService.GetProjectAsync(id);
            return Ok(project);
        }

        [HttpGet("DropDown")]
        public async Task<IActionResult> GetProjectsForDropDownAsync()
        {
            var project = await _projectService.GetProjectsForDropDownAsync();
            return Ok(project);
        }

        [HttpPost]
        [HasPermission(Permissions.CanAddProject)]
        public async Task<IActionResult> CreateProjectAsync(CreateProjectRequest dto)
        {
            var project = await _projectService.CreateProjectAsync(dto);
            return Ok(project);
        }
        
        [HttpPut]
        [HasPermission(Permissions.CanAddProject)]
        public async Task<IActionResult> UpdateProjectAsync(UpdateProjectRequest d)
        {
            var project = await _projectService.UpdateProjectAsync(d);
            return Ok(project);
        }
    }
}
