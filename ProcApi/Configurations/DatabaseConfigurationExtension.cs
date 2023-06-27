using Microsoft.EntityFrameworkCore;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase;
using System.Text.Json;

namespace ProcApi.Configurations
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var a = configuration.GetSection(nameof(ConnectionStrings));

            var connectionStrings = JsonSerializer.Deserialize<ConnectionStrings>(
                configuration.GetSection(nameof(ConnectionStrings)));

            services.AddDbContext<ProcDbContext>(options => options.UseSqlServer(connectionStrings.ProcConnectionString));
        }
    }
}
