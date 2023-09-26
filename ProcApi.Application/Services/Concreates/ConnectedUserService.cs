using Microsoft.Extensions.Caching.Distributed;
using ProcApi.Application.Caches;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Extensions;

namespace ProcApi.Application.Services.Concreates;

public class ConnectedUserService : IConnectedUsersService
{
    private readonly IDistributedCache _cache;

    public ConnectedUserService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task AddUserAsync(int userId, string connectionId)
    {
        var users = await GetConnectedUsersAsync();

        if (users.TryGetValue(userId, out var connectionIds))
            connectionIds.Add(connectionId);
        else
            users.Add(userId, new List<string>() { connectionId });

        await _cache.SetAsync(CacheKeys.CONNECTED_USERS, users);
    }

    public async Task RemoveUserAsync(int userId)
    {
        var users = await GetConnectedUsersAsync();

        users.Remove(userId);

        await _cache.SetAsync(CacheKeys.CONNECTED_USERS, users);
    }

    public async Task<List<string>> GetConnectionsAsync(int userId)
    {
        var users = await GetConnectedUsersAsync();

        if (users.TryGetValue(userId, out var connectionIds))
            return connectionIds;

        return new List<string>();
    }

    public async Task<List<string>> GetConnectionsAsync(IEnumerable<int> userIds)
    {
        var connectionIds = new List<string>();

        var connectedUsers = await GetConnectedUsersAsync();

        foreach (var userId in userIds)
        {
            if (connectedUsers.TryGetValue(userId, out var connections))
                connectionIds.AddRange(connections);
        }

        return connectionIds;
    }

    public async Task RemoveConnectionIdAsync(string connectionId)
    {
        var users = await GetConnectedUsersAsync();

        foreach (var user in users)
        {
            if (user.Value.Contains(connectionId))
            {
                if (user.Value.Count == 1)
                    users.Remove(user.Key);
                else
                    user.Value.Remove(connectionId);

                return;
            }
        }

        await _cache.SetAsync(CacheKeys.CONNECTED_USERS, users);
    }

    public async Task<Dictionary<int, List<string>>> GetConnectedUsersAsync()
    {
        var users = await _cache.GetAsync<Dictionary<int, List<string>>>(CacheKeys.CONNECTED_USERS);

        return users ?? new Dictionary<int, List<string>>();
    }
}