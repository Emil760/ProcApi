using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;

namespace ProcApi.Infrastructure.Extensions;

public static class DistributedCacheExtensions
{
    public static Task SetAsync<T>(this IDistributedCache cache, string key, T value)
    {
        return SetAsync(cache, key, value, _distributedCacheEntryOptions);
    }

    public static Task SetAsync<T>(this IDistributedCache cache, string key, T value,
        DistributedCacheEntryOptions options)
    {
        var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _serializerOptions));
        return cache.SetAsync(key, bytes, options);
    }

    public static async Task<T?> GetAsync<T>(this IDistributedCache cache, string key)
    {
        var bytes = await cache.GetAsync(key);
        if (bytes is null)
            return default(T);

        return JsonSerializer.Deserialize<T>(bytes);
    }

    public static bool TryGetValue<T>(this IDistributedCache cache, string key, out T? value)
    {
        var val = cache.Get(key);
        value = default;
        if (val == null) return false;
        value = JsonSerializer.Deserialize<T>(val, _serializerOptions);
        return true;
    }

    private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = null,
        WriteIndented = true,
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private static DistributedCacheEntryOptions _distributedCacheEntryOptions = new DistributedCacheEntryOptions
    {
        SlidingExpiration = TimeSpan.FromHours(1)
    };
}