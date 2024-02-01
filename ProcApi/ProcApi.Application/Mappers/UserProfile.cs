using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Mappers;

public class UserProfile : CommonProfile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>();
        
        CreateMap<User, UserInfoResponseDto>();

        CreateMap<User, UserWithRolesResponseDto>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => string.Join(", ", src.Roles.Select(r => r.Name))));

        CreateMap<AddUserDto, User>();
    }
}