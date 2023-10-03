using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IUserService
{
    Task<UserResponseDto> GetByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetUsersAsync();
    Task<UserResponseDto> AddUserAsync(AddUserDto dto);
    Task<bool> AlreadyExists(string login);
    Task<IEnumerable<string>> GetAllRoleNames(int userId);
    Task<IEnumerable<string>> GetPermissionNames(int userId);
}