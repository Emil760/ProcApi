using Microsoft.EntityFrameworkCore;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase;

namespace ProcApi.Configurations
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var procConnectionString = configuration.GetSection(nameof(ConnectionStrings)).GetChildren().ElementAt(0).Value;

            services.AddDbContext<ProcDbContext>(options => options.UseSqlServer(procConnectionString));
        }
    }
}
