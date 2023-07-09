using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ProcApi.Configurations
{
    public static class LocalizationConfiguration
    {
        public static void AddCustomLocalization(this IServiceCollection services)
        {
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("az-Latn-AZ") ,
                    new CultureInfo("en-US")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.ApplyCurrentCultureToResponseHeaders = true;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };

            });
        }

        public static void UseCustomLocalization(this IApplicationBuilder app)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
        }
    }
}
