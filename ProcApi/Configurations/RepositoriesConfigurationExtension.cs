using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.Concreates;
using ProcApi.Repositories.UnitOfWork;

namespace ProcApi.Configurations
{
    public static class RepositoriesConfigurationExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSettingRepository, UserSettingRepository>();
            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentActionRepository, DocumentActionRepository>();
            services.AddScoped<IApprovalFlowTemplateRepository, ApprovalFlowTemplateRepository>();
            services.AddScoped<IPurchaseRequestDocumentRepository, PurchaseRequestDocumentRepository>();
        }
    }
}
