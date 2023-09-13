using AutoMapper;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.DTOs.User.Base;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class PurchaseRequestDocumentService : IPurchaseRequestDocumentService
    {
        private readonly IDocumentService _documentService;
        private readonly IApprovalFlowService _approvalFlowService;
        private readonly IPurchaseRequestDocumentRepository _purchaseRequestDocumentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequestDocumentService(IDocumentService documentService,
            IApprovalFlowService approvalFlowService,
            IPurchaseRequestDocumentRepository purchaseRequestDocumentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _documentService = documentService;
            _approvalFlowService = approvalFlowService;
            _purchaseRequestDocumentRepository = purchaseRequestDocumentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseRequestDocumentResponseDto> CreateDocument(UserInfo? userInfo,
            CreatePurchaseRequestDocumentRequestDto requestDto)
        {
            var document = _documentService.CreateDocument(userInfo.UserId,
                DocumentType.PurchaseRequest,
                DocumentStatus.PurchaseRequestDraft);

            var documentActions = await _approvalFlowService.CreateApprovals(userInfo,
                document,
                DocumentType.PurchaseRequest);

            document.DocumentActions = documentActions.ToList();

            var itemModels = _mapper.Map<ICollection<PurchaseRequestDocumentItem>>(requestDto.Items);

            var purchaseRequestDocument = new PurchaseRequestDocument()
            {
                Document = document,
                Description = requestDto.Description,
                RequestedForDepartmentId = requestDto.DepartmentId,
                DeliveryAddress = requestDto.DeliveryAddress,
                Items = itemModels
            };

            await _purchaseRequestDocumentRepository.InsertAsync(purchaseRequestDocument);

            return _mapper.Map<PurchaseRequestDocumentResponseDto>(purchaseRequestDocument);
        }
    }
}