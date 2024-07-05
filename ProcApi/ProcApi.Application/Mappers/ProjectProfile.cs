using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers
{
    public class ProjectProfile : CommonProfile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
            CreateMap<UpdateProjectRequest, Project>();
            
            CreateMap<Project, DropDownDto<int>>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
        }
    }
}
