using ProcApi.Infrastructure.Options;
using FileOptions = ProcApi.Infrastructure.Options.FileOptions;

namespace ProcApi.Presentation.Configurations;

public static class OptionsConfigurationExtension
{
    public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ProcDatabaseOptions>(
            configuration.GetSection(nameof(ProcDatabaseOptions)));

        services.Configure<RedisOptions>(
            configuration.GetSection(nameof(RedisOptions)));

        services.Configure<FilePaths>(
            configuration.GetSection(nameof(FilePaths)));

        services.Configure<FileOptions>(
            configuration.GetSection(nameof(FileOptions)));

        services.Configure<JwtOptions>(
            configuration.GetSection(nameof(JwtOptions)));

        services.Configure<PasswordOptions>(
            configuration.GetSection(nameof(PasswordOptions)));

        services.Configure<RabbitMqOptions>(
            configuration.GetSection(nameof(RabbitMqOptions)));
            
        services.Configure<UserOptions>(
            configuration.GetSection(nameof(UserOptions)));
    }
}