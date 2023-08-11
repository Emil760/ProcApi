using ProcApi.Caches;
using ProcApi.Configurations.Options;

namespace ProcApi.Configurations
{
    public static class RedisCacheConfiguration
    {
        public static void AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection(nameof(RedisOptions)).GetChildren().ElementAt(0).Value;

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });
        }
    }
}
