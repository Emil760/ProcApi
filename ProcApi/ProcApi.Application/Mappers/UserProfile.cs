using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class UserProfile : CommonProfile
{
    public UserProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<User, UserInfoResponse>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department == null ? "" : src.Department.Name));

        CreateMap<User, UserWithRolesResponse>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => string.Join(", ", src.Roles.Select(r => r.Name))));

        CreateMap<AddUserRequest, User>();
    }
}