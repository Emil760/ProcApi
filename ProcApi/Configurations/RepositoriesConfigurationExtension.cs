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


            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentActionRepository, DocumentActionRepository>();
            services.AddScoped<IApprovalFlowTemplateRepository, ApprovalFlowTemplateRepository>();
            services.AddScoped<IReleaseStrategyRepository, ReleaseStrategyRepository>();

            services.AddScoped<IPurchaseRequestDocumentRepository, PurchaseRequestDocumentRepository>();
            services.AddScoped<IPurchaseRequestDocumentItemsRepository, PurchaseRequestDocumentItemsRepository>();

            services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IChatUserRepository, ChatUserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupUserRepository, GroupUserRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
        }
    }
}