
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IProjectSercive
    {
        Task<ProjectResponseDto> CreateProjectAsync(CreateProjectRequestDto dto);
        Task<IEnumerable<ProjectResponseDto>> GetProjectsAsync();
        Task<IEnumerable<DropDownDto<int>>> GetProjectsForDropDownAsync();
    }
}
