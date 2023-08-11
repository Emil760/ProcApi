using AutoMapper;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;
using ProcApi.ViewModels.User;

namespace ProcApi.Mappers
{
    public class CommonAutoMapperProfile : Profile
    {
        public CommonAutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<AddUserDto, User>();
        }
    }
}
