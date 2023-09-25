using AutoMapper;
using ProcApi.Mappers;

namespace ProcApi.Configurations
{
    public static class MapperConfigurationExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommonProfile());
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new PurchaseRequestProfile());
                cfg.AddProfile(new PurchaseRequestItemProfile());
                cfg.AddProfile(new ChatProfile());
                cfg.AddProfile(new MaterialProfile());
                cfg.AddProfile(new CategoryProfile());
            }).CreateMapper());
        }
    }
}