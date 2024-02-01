using ProcApi.Application.DTOs.User.Responses;

namespace ProcApi.Application.Caches.Abstracts;

public interface IUserCachedService
{
    Task<UserInfoResponseDto> GetByIdAsync(int id);
}