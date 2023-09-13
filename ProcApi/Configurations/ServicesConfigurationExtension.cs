﻿using ProcApi.Caches.Abstracts;
using ProcApi.Caches.Concreates;
using ProcApi.Handlers.Exception;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;
using ProcApi.Services.Concreates;

namespace ProcApi.Configurations
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

            services.AddScoped<IGroupChatSignalService, GroupChatSignalService>();

            services.AddScoped<IApprovalFlowService, ApprovalFlowService>();

            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPurchaseRequestDocumentService, PurchaseRequestDocumentService>();
            services.AddScoped<IPurchaseRequestDocumentApprovalService, PurchaseRequestDocumentApprovalService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IUserCachedService, UserCachedService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ExceptionHandlerCoordinator>();
            services.AddScoped<GeneralExceptionHandler>();
            services.AddScoped<UnauthorizedExceptionHandler>();
            services.AddScoped<NotFoundExceptionHandler>();
            services.AddScoped<ValidationExceptionHandler>();
        }
    }
}