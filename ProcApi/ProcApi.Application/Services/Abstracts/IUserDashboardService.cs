using ProcApi.Application.DTOs.Dashboard.Requests;
using ProcApi.Application.DTOs.Dashboard.Responses;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IUserDashboardService
    {
        Task<int> CreateDashboardAsync(int userId, AddDashboardRequest dto);
        Task<IEnumerable<DashboardResponse>> GetAllByUserIdAsync(int userId);
        Task<IEnumerable<DocumentStatus>> GetSectionsAsync(int userDashboardId);
        Task ManageSectionAsync(ManageSectionRequest dto);
    }
}
