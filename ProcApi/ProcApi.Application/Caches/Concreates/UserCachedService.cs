using Microsoft.Extensions.Caching.Distributed;
using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Extensions;

namespace ProcApi.Application.Caches.Concreates;

public class UserCachedService : IUserCachedService
{
    private readonly IUserService _userService;
    private readonly IDistributedCache _cache;

    public UserCachedService(IUserService userService,
        IDistributedCache cache)
    {
        _userService = userService;
        _cache = cache;
    }

    public async Task<UserInfoResponseDto> GetByIdAsync(int id)
    {
        var key = CacheKeys.GetUserKey(id);
        var user = await _cache.GetAsync<UserInfoResponseDto>(key);

        if (user is null)
        {
            user = await _userService.GetByIdAsync(id);
            await _cache.SetAsync(key, user);
        }

        return user;
    }
}