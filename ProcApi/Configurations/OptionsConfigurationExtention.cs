using ProcApi.Configurations.Options;

namespace ProcApi.Configurations
{
    public static class OptionsConfigurationExtention
    {
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var a = configuration.GetSection(nameof(ConnectionStrings));

            services.Configure<ConnectionStrings>(
                configuration.GetSection(nameof(ConnectionStrings)));
        }
    }
}
