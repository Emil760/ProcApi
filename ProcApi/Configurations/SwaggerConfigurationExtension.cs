using Microsoft.OpenApi.Models;

namespace ProcApi.Configurations
{
    public static class SwaggerConfigurationExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProcApi", Version = "v1" });
            });
        }
    }
}
