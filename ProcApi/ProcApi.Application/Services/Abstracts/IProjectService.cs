
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IProjectService
    {
        Task<ProjectResponse> CreateProjectAsync(CreateProjectRequest dto);
        Task<IEnumerable<ProjectResponse>> GetProjectsAsync();
        Task<ProjectResponse> GetProjectAsync(int id);
        Task<IEnumerable<DropDownDto<int>>> GetProjectsForDropDownAsync();
        Task<ProjectResponse> UpdateProjectAsync(UpdateProjectRequest d);
    }
}
