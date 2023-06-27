using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.Concreates;

namespace ProcApi.Configurations
{
    public static class RepositoriesConfigurationExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
