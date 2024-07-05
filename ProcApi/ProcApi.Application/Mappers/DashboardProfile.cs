using ProcApi.Application.DTOs;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers
{
    public class DashboardProfile : CommonProfile
    {
        public DashboardProfile()
        {
            CreateMap<Dashboard, DropDownDto<int>>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Name));
        }
    }
}
