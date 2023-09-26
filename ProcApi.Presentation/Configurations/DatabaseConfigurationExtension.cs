using Microsoft.EntityFrameworkCore;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Options;

namespace ProcApi.Presentation.Configurations
{
    public static class DatabaseConfigurationExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseOptions = new ProcDatabaseOptions();

            configuration.GetSection(nameof(ProcDatabaseOptions)).Bind(databaseOptions);

            services.AddDbContext<ProcDbContext>(options =>
            {
                options.UseNpgsql(databaseOptions.ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                    sqlServerOptions.CommandTimeout(databaseOptions.CommandTimeout);
                });

                options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
                options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });
            
            //TODO
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
