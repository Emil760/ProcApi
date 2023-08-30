using AutoMapper;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.PurchaseRequestDocument;
using ProcApi.DTOs.User;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class PurchaseRequestDocumentApprovalService : IPurchaseRequestDocumentApprovalService
{
    private readonly IApprovalFlowService _approvalFlowService;
    private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;
    private readonly IPurchaseRequestDocumentRepository _purchaseRequestDocumentRepository;
    private readonly IDocumentService _documentService;
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentActionRepository _documentActionRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    private readonly Dictionary<ActionType, Func<Task>> _actionDictionary = new()
    {
        { ActionType.Approve, Approve },
        { ActionType.SaveAsDraft, SaveAsDraft }
    };

    public PurchaseRequestDocumentApprovalService(IPurchaseRequestDocumentService purchaseRequestDocumentService,
        IApprovalFlowService approvalFlowService,
        IDocumentService documentService,
        IPurchaseRequestDocumentRepository purchaseRequestDocumentRepository,
        IDocumentRepository documentRepository,
        IDocumentActionRepository documentActionRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _purchaseRequestDocumentService = purchaseRequestDocumentService;
        _approvalFlowService = approvalFlowService;
        _documentService = documentService;
        _purchaseRequestDocumentRepository = purchaseRequestDocumentRepository;
        _documentRepository = documentRepository;
        _documentActionRepository = documentActionRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PurchaseRequestDocumentDto> CreateDocument(UserInfoDro userInfoDro,
        CreatePurchaseRequestDocumentDto dto)
    {
        var document = _documentService.CreateDocument(userInfoDro.UserId,
            DocumentType.PurchaseRequest,
            DocumentStatus.PurchaseRequestDraft);

        var documentActions = await _approvalFlowService.CreateApprovals(userInfoDro,
            document,
            DocumentType.PurchaseRequest);

        document.DocumentActions = documentActions.ToList();

        var purchaseRequestDocument = new PurchaseRequestDocument()
        {
            Document = document,
            RequestedForDepartmentId = dto.DepartmentId,
            DeliveryAddress = dto.DeliveryAddress
        };

        _purchaseRequestDocumentRepository.Insert(purchaseRequestDocument);

        await _unitOfWork.SaveChangesAsync();
        //
        // var purchaseRequestDocumentDto = new PurchaseRequestDocumentDto();
        // return _mapper.Map(purchaseRequestDocument, purchaseRequestDocumentDto);

        return null;
    }

    public async Task PerformAction(ActionPerformDto dto)
    {
        var action = _actionDictionary[dto.ActionType];

        await action.Invoke();
    }

    private static async Task Approve()
    {
    }

    private static async Task SaveAsDraft()
    {
    }

    public async Task Return()
    {
    }

    public async Task Reject()
    {
    }

    public async Task Reconcile()
    {
    }

    public async Task ValidateForApprove()
    {
    }

    public async Task ValidateForDraft()
    {
    }
}