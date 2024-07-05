using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IUserService
{
    Task<UserInfoResponse> GetByIdAsync(int id);
    Task<IEnumerable<UserInfoResponse>> GetAllInfosAsync();
    Task<IEnumerable<UserWithRolesResponse>> GetUsersWithRolesAsync(string? search);
    Task<UserResponse> AddUserAsync(AddUserRequest request);
    Task<IEnumerable<string>> GetAllRoleNames(int userId);
    Task<IEnumerable<string>> GetPermissionNames(int userId);
    Task<IEnumerable<UserResponse>> GetAllByRoleAsync(int roleId);
    Task<IEnumerable<UserResponse>> GetAllByRoleNameAsync(string name);
    Task GrantRoleAsync(GrantRoleRequest dto);
    Task RemoveRoleAsync(RemoveRoleRequest dto);
    Task AssignDashboardAsync(AssignDashboardRequest dto);
    Task AssignDepartmentAsync(AssignDepartmentRequest request);
}