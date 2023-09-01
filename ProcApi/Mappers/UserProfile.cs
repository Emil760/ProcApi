using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User.Requests;
using ProcApi.DTOs.User.Responses;

namespace ProcApi.Mappers
{
    public class UserProfile : CommonProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
