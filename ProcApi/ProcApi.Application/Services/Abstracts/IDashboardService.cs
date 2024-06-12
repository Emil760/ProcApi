using ProcApi.Application.DTOs;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IDashboardService
    {
        Task<IEnumerable<DropDownDto<int>>> GetDashboardsForDropDownAsync();
    }
}
