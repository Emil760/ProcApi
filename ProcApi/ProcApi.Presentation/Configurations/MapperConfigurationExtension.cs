using AutoMapper;
using ProcApi.Application.Mappers;

namespace ProcApi.Presentation.Configurations;

public static class MapperConfigurationExtension
{
    private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
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
        cfg.AddProfile(new DelegationProfile());
        cfg.AddProfile(new DepartmentProfile());
        cfg.AddProfile(new UnitOfMeasureProfile());
        cfg.AddProfile(new DashboardProfile());
        cfg.AddProfile(new ProjectProfile());
        cfg.AddProfile(new AnnualProcurementProfile());
    }).CreateMapper();

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddSingleton(_mapper);
    }

    public static IMapper Initialize()
    {
        return _mapper;
    }
}