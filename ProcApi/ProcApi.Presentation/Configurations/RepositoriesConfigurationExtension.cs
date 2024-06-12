﻿using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.Concreates;
using ProcApi.Infrastructure.Repositories.UnitOfWork;

namespace ProcApi.Presentation.Configurations;

public static class RepositoriesConfigurationExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserSettingRepository, UserSettingRepository>();
        services.AddScoped<IDelegationRepository, DelegationRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        services.AddScoped<IDocumentValidationConfigurationRepository, DocumentValidationConfigurationRepository>();

        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IDocumentActionRepository, DocumentActionRepository>();
        services.AddScoped<IApprovalFlowTemplateRepository, ApprovalFlowTemplateRepository>();
        services.AddScoped<IReleaseStrategyTemplateRepository, ReleaseStrategyTemplateTemplatesRepository>();

        services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();
        services.AddScoped<IPurchaseRequestItemsRepository, PurchaseRequestItemsRepository>();

        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

        services.AddScoped<ISupplierRepository, SupplierRepository>();

        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IChatUserRepository, ChatUserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IGroupUserRepository, GroupUserRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasuresRepository>();
        services.AddScoped<IUnitOfMeasureConverterRepository, UnitOfMeasureConverterRepository>();
    }
}