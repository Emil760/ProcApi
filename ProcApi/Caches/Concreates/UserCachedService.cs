﻿using Microsoft.Extensions.Caching.Distributed;
using ProcApi.Caches.Abstracts;
using ProcApi.Extensions;
using ProcApi.Services.Abstracts;
using ProcApi.ViewModels.User;

namespace ProcApi.Caches.Concreates
{
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

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var key = CacheKeys.GetUserKey(id);
            var user = await _cache.GetAsync<UserViewModel>(key);

            if (user is null)
            {
                user = await _userService.GetByIdAsync(id);
                await _cache.SetAsync(key, user);
            }

            return user;
        }
    }
}
