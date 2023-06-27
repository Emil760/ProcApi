using AutoMapper;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.ViewModel;

namespace ProcApi.Mappers
{
    public class CommonAutoMapperProfile : Profile
    {
        public CommonAutoMapperProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
