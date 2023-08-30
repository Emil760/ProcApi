using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;
using ProcApi.ViewModels.User;

namespace ProcApi.Mappers
{
    public class UserProfile : CommonProfile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<AddUserDto, User>();
        }
    }
}
