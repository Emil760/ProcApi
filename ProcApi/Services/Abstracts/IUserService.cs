using ProcApi.DTOs.User.Requests;
using ProcApi.DTOs.User.Responses;

namespace ProcApi.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetUsersAsync();
        Task<UserResponseDto> AddUserAsync(AddUserDto dto);
        Task<bool> AlreadyExists(string login);
    }
}
