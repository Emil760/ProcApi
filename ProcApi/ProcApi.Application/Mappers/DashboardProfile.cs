using ProcApi.Application.DTOs;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers
{
    public class DashboardProfile : CommonProfile
    {
        public DashboardProfile()
        {
            CreateMap<Dashboard, DropDownDto<int>>();
        }
    }
}
