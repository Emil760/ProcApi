using AutoMapper;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Application.Services.Concreates;

public class DocumentService : IDocumentService
{
    private readonly IApprovalsService _approvalsService;
    private readonly IDocumentRepository _documentRepository;
    private readonly IMapper _mapper;

    public DocumentService(IApprovalsService approvalsService,
        IDocumentRepository documentRepository,
        IMapper mapper)
    {
        _approvalsService = approvalsService;
        _mapper = mapper;
        _documentRepository = documentRepository;
    }

    public async Task<DocumentResponseDto> CreateDocumentWithApprovals(UserInfoModel userInfo,
        DocumentType type,
        DocumentStatus status)
    {
        var document = new Document()
        {
            CreatedById = userInfo.UserId,
            TypeId = type,
            StatusId = status,
            CreatedOn = DateTime.Now
        };

        var documentActions =
            await _approvalsService.InitApprovals(userInfo.UserId, DocumentType.PurchaseRequest);

        document.Actions = documentActions.ToList();

        await _documentRepository.InsertAsync(document);

        return _mapper.Map<DocumentResponseDto>(document);
    }
}