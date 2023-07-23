using ProcApi.Configurations.Options;

namespace ProcApi.Configurations
{
    public static class OptionsConfigurationExtention
    {
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProcDatabaseOptions>(
                configuration.GetSection(nameof(ProcDatabaseOptions)));

            services.Configure<RedisOptions>(
                configuration.GetSection(nameof(RedisOptions)));

            services.Configure<FilePaths>(
                configuration.GetSection(nameof(FilePaths)));

            services.Configure<Options.FileOptions>(
                configuration.GetSection(nameof(Options.FileOptions)));
        }
    }
}
