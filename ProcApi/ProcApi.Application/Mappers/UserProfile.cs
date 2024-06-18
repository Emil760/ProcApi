using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class UserProfile : CommonProfile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>();

        CreateMap<User, UserInfoResponseDto>()
            .ForMember(dest => dest.DashboardName, opt => opt.MapFrom(src => src.Dashboard == null ? "" : src.Dashboard.Name))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department == null ? "" : src.Department.Name));

        CreateMap<User, UserWithRolesResponseDto>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => string.Join(", ", src.Roles.Select(r => r.Name))));

        CreateMap<AddUserDto, User>();
    }
}