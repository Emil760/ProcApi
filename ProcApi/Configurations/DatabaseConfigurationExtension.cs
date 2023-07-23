using Microsoft.EntityFrameworkCore;
using ProcApi.Configurations.Options;
using ProcApi.Data.ProcDatabase;

namespace ProcApi.Configurations
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = new ProcDatabaseOptions();

            configuration.GetSection(nameof(ProcDatabaseOptions)).Bind(databaseOptions);

            services.AddDbContext<ProcDbContext>(options =>
            {
                options.UseSqlServer(databaseOptions.ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerOptions.CommandTimeout(databaseOptions.CommandTimeout);
                });

                options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(databaseOptions.EnableSensetiveDataLogging);
            });
        }
    }
}
