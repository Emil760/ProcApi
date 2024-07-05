using ProcApi.Application.Caches.Abstracts;
using ProcApi.Application.Caches.Concreates;
using ProcApi.Application.Handlers.Document;
using ProcApi.Application.Handlers.Invoice;
using ProcApi.Application.Handlers.PurchaseRequest;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Application.Services.Concreates;
using ProcApi.Presentation.Handlers.Exception;

namespace ProcApi.Presentation.Configurations;

public static class ServicesConfigurationExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IDelegationService, DelegationService>();
        services.AddScoped<IUserCachedService, UserCachedService>();

        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDashboardService, DashboardService>();

        services.AddSingleton<IConnectedUsersService, ConnectedUserService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IChatMessageService, ChatMessageService>();
        services.AddScoped<IChatGroupService, ChatGroupService>();

        services.AddScoped<IChatMessageSignalService, ChatMessageSignalService>();
        services.AddScoped<IGroupChatSignalService, GroupChatSignalService>();

        services.AddScoped<IApprovalsService, ApprovalsService>();

        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();
        services.AddScoped<IPurchaseRequestItemsService, PurchaseRequestItemsService>();
        services.AddScoped<IPurchaseRequestApprovalService, PurchaseRequestApprovalService>();

        services.AddScoped<PurchaseRequestApproveHandler>();
        services.AddScoped<PurchaseRequestRejectHandler>();
        services.AddScoped<PurchaseRequestReturnHandler>();
        services.AddScoped<PurchaseRequestSubmitHandler>();

        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IInvoiceApprovalService, InvoiceApprovalService>();

        services.AddScoped<InvoiceApproveHandler>();
        services.AddScoped<InvoiceRejectHandler>();
        services.AddScoped<InvoiceReturnHandler>();
        services.AddScoped<InvoiceSubmitHandler>();

        services.AddScoped<IGoodIssueNoteService, GoodIssueNoteService>();
        
        services.AddScoped<IDocumentValidatorHandler, DocumentValidatorHandler>();
        services.AddScoped<PurchaseRequestValidator>();
        services.AddScoped<InvoiceValidator>();

        services.AddScoped<ISupplierService, SupplierService>();

        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();

        services.AddScoped<IAnnualProcurementService, AnnualProcurementService>();

        services.AddScoped<IFileService, FileService>();

        services.AddScoped<IDropDownService, DropDownService>();

        services.AddScoped<ExceptionHandlerCoordinator>();
        services.AddScoped<GeneralExceptionHandler>();
        services.AddScoped<UnauthorizedExceptionHandler>();
        services.AddScoped<NotFoundExceptionHandler>();
        services.AddScoped<ValidationExceptionHandler>();
        services.AddScoped<MultipleExceptionHandler>();
        services.AddScoped<ItemsExceptionHandler>();
    }
}