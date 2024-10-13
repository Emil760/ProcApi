using ProcApi.Application.DTOs.Dashboard.Requests;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class UserDashboardProfile : CommonProfile
{
    public UserDashboardProfile()
    {
        CreateMap<AddDashboardRequest, UserDashboard>();
    }
}