using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class UserProfile : CommonProfile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<AddUserDto, User>();
    }
}