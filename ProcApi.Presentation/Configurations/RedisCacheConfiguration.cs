using ProcApi.Infrastructure.Options;

namespace ProcApi.Presentation.Configurations
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
