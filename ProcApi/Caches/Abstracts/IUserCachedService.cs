using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User.Responses;

namespace ProcApi.Caches.Abstracts
{
    public interface IUserCachedService
    {
        Task<UserResponseDto> GetByIdAsync(int id);
    }
}
