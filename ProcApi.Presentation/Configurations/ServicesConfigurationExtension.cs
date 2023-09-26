using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.Caches.Concreates;
using ProcApi.Application.Handlers.PurchaseRequestDocument;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Application.Services.Concreates;
using ProcApi.Presentation.Handlers.Exception;

namespace ProcApi.Presentation.Configurations
{
    public static class ServicesConfigurationExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IConnectedUsersService, ConnectedUserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatMessageService, ChatMessageService>();
            services.AddScoped<IChatGroupService, ChatGroupService>();

            services.AddScoped<IChatMessageSignalService, ChatMessageSignalService>();
            services.AddScoped<IGroupChatSignalService, GroupChatSignalService>();

            services.AddScoped<IApprovalsService, ApprovalsService>();

            services.AddScoped<IDocumentService, DocumentService>();

            services.AddScoped<IPurchaseRequestDocumentService, PurchaseRequestDocumentService>();
            services.AddScoped<IPurchaseRequestDocumentItemsService, PurchaseRequestDocumentItemsService>();
            services.AddScoped<IPurchaseRequestDocumentApprovalService, PurchaseRequestDocumentApprovalService>();

            services.AddScoped<PurchaseRequestApproveHandler>();
            services.AddScoped<PurchaseRequestRejectHandler>();
            services.AddScoped<PurchaseRequestReturnHandler>();
            services.AddScoped<PurchaseRequestSubmitHandler>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMaterialService, MaterialService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IUserCachedService, UserCachedService>();
            
            services.AddScoped<ExceptionHandlerCoordinator>();
            services.AddScoped<GeneralExceptionHandler>();
            services.AddScoped<UnauthorizedExceptionHandler>();
            services.AddScoped<NotFoundExceptionHandler>();
            services.AddScoped<ValidationExceptionHandler>();
        }
    }
}