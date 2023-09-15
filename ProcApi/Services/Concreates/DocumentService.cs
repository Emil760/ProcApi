using AutoMapper;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents.Responses;
using ProcApi.DTOs.User.Base;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class DocumentService : IDocumentService
{
    private readonly IApprovalsService _approvalsService;
    private readonly IMapper _mapper;

    public DocumentService(IApprovalsService approvalsService,
        IMapper mapper)
    {
        _approvalsService = approvalsService;
        _mapper = mapper;
    }

    public async Task<DocumentResponseDto> CreateDocumentWithApprovals(UserInfo userInfo, 
        DocumentType type,
        DocumentStatus status)
    {
        var document = new Document()
        {
            CreatedById = userInfo.UserId,
            DocumentTypeId = type,
            DocumentStatusId = status,
            CreatedOn = DateTime.Now
        };

        var documentActions =
            await _approvalsService.InitApprovals(userInfo.UserId, DocumentType.PurchaseRequest);

        document.DocumentActions = documentActions.ToList();

        return _mapper.Map<DocumentResponseDto>(document);

        //var itemModels = _mapper.Map<ICollection<PurchaseRequestDocumentItem>>(requestDto.Items);

        // var purchaseRequestDocument = new PurchaseRequestDocument()
        // {
        //     Document = document,
        //     Description = requestDto.Description,
        //     RequestedForDepartmentId = requestDto.DepartmentId,
        //     DeliveryAddress = requestDto.DeliveryAddress,
        //     //Items = itemModels
        // };

        //await _purchaseRequestDocumentRepository.InsertAsync(purchaseRequestDocument);

        //return _mapper.Map<PurchaseRequestDocumentResponseDto>(purchaseRequestDocument);
    }
    
}