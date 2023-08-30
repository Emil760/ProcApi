using ProcApi.Caches.Abstracts;
using ProcApi.Caches.Concreates;
using ProcApi.Filters;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;
using ProcApi.Services.Concreates;

namespace ProcApi.Configurations
{
    public static class ServicesConfigurationExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IApprovalFlowService, ApprovalFlowService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPurchaseRequestDocumentService, PurchaseRequestDocumentService>();
            services.AddScoped<IPurchaseRequestDocumentApprovalService, PurchaseRequestDocumentApprovalService>();

            services.AddScoped<IUserCachedService, UserCachedService>();

            services.AddScoped<CustomValidationFilterAttribute>();
        }
    }
}