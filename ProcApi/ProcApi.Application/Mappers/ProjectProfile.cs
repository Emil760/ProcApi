using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers
{
    public class ProjectProfile : CommonProfile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectRequestDto, Project>();
            CreateMap<Project, ProjectResponseDto>();
        }
    }
}
