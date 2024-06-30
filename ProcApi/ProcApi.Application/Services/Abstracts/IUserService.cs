using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IUserService
{
    Task<UserInfoResponseDto> GetByIdAsync(int id);
    Task<IEnumerable<UserInfoResponseDto>> GetAllInfosAsync();
    Task<IEnumerable<UserWithRolesResponseDto>> GetUsersWithRolesAsync(string? search);
    Task<UserResponseDto> AddUserAsync(AddUserDto dto);
    Task<IEnumerable<string>> GetAllRoleNames(int userId);
    Task<IEnumerable<string>> GetPermissionNames(int userId);
    Task<IEnumerable<UserResponseDto>> GetAllByRoleAsync(int roleId);
    Task<IEnumerable<UserResponseDto>> GetAllByRoleNameAsync(string name);
    Task GrantRoleAsync(GrantRoleRequestDto dto);
    Task RemoveRoleAsync(RemoveRoleRequestDto dto);
    Task AssignDashboardAsync(AssignDashboardRequestDto dto);
    Task AssignDepartmentAsync(AssignDepartmentRequestDto requestDto);
}