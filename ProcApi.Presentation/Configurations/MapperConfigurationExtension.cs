using AutoMapper;
using ProcApi.Application.Mappers;

namespace ProcApi.Presentation.Configurations
{
    public static class MapperConfigurationExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(_ => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommonProfile());
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new PurchaseRequestProfile());
                cfg.AddProfile(new PurchaseRequestItemProfile());
                cfg.AddProfile(new ChatProfile());
                cfg.AddProfile(new MaterialProfile());
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new SupplierProfile());
                cfg.AddProfile(new InvoiceProfile());
                cfg.AddProfile(new InvoiceItemProfile());
            }).CreateMapper());
        }
    }
}