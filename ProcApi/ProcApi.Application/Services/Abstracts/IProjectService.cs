
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IProjectService
    {
        Task<ProjectResponseDto> CreateProjectAsync(CreateProjectRequestDto dto);
        Task<IEnumerable<ProjectResponseDto>> GetProjectsAsync();
        Task<ProjectResponseDto> GetProjectAsync(int id);
        Task<IEnumerable<DropDownDto<int>>> GetProjectsForDropDownAsync();
        Task<ProjectResponseDto> UpdateProjectAsync(UpdateProjectRequestDto dto);
    }
}
