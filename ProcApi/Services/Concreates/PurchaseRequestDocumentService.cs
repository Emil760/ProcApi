using AutoMapper;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.DTOs.User.Base;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class PurchaseRequestDocumentService : IPurchaseRequestDocumentService
    {
        private readonly IDocumentService _documentService;
        private readonly IApprovalsService _approvalsService;
        private readonly IPurchaseRequestDocumentRepository _purchaseRequestDocumentRepository;
        private readonly IMapper _mapper;


        public PurchaseRequestDocumentService(IDocumentService documentService,
            IApprovalsService approvalsService,
            IPurchaseRequestDocumentRepository purchaseRequestDocumentRepository,
            IMapper mapper
        )
        {
            _documentService = documentService;
            _approvalsService = approvalsService;
            _purchaseRequestDocumentRepository = purchaseRequestDocumentRepository;
            _mapper = mapper;
        }

        public async Task<PurchaseRequestDocumentResponseDto> GetDocument(int docId)
        {
            var document = await _purchaseRequestDocumentRepository.GetDocumentWithActionsAndItems(docId);

            return _mapper.Map<PurchaseRequestDocumentResponseDto>(document);
        }

        public async Task SaveDocument(UserInfo userInfo, CreatePurchaseRequestDocumentRequestDto dto)
        {
            var document = await _purchaseRequestDocumentRepository.GetDocumentWithItems(dto.DocumentId);

            if (document is null)
                await CreateDocument(dto);
            else
                await UpdateDocument(document, dto);
        }

        private async Task CreateDocument(CreatePurchaseRequestDocumentRequestDto dto)
        {
        }

        private async Task UpdateDocument(PurchaseRequestDocument purchaseRequestDocument,
            CreatePurchaseRequestDocumentRequestDto dto)
        {
        }
    }
}