﻿using ProcApi.Caches.Abstracts;
using ProcApi.Caches.Concreates;
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

            services.AddScoped<IApprovalFlowService, ApprovalFlowService>();

            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPurchaseRequestDocumentService, PurchaseRequestDocumentService>();
            services.AddScoped<IPurchaseRequestDocumentApprovalService, PurchaseRequestDocumentApprovalService>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IUserCachedService, UserCachedService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}