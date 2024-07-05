using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DepartmentProfile : CommonProfile
{
    public DepartmentProfile()
    {
        CreateMap<CreateDepartmentRequest, Department>();

        CreateMap<Department, DepartmentResponse>();

        CreateMap<Department, DepartmentListResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.HeadUserName, opt => opt.MapFrom(src => src.HeadUser.FirstName));
    }
}