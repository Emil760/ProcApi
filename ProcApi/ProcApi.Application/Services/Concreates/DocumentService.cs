using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;

namespace ProcApi.Application.Services.Concreates;

public class DocumentService : IDocumentService
{
    private readonly IApprovalsService _approvalsService;
    private readonly IDocumentRepository _documentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DocumentService(IApprovalsService approvalsService,
        IDocumentRepository documentRepository,
        IUnitOfWork unitOfWork)
    {
        _approvalsService = approvalsService;
        _documentRepository = documentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Document> CreateDocumentWithApprovalsAsync(UserInfoModel userInfo,
        DocumentType type,
        DocumentStatus status)
    {
        var document = new Document
        {
            CreatedById = userInfo.UserId,
            DocumentTypeId = type,
            DocumentStatusId = status,
            CreatedOn = DateTime.Now,
            FlowCodes = FlowCodes.STANDART
        };

        await _documentRepository.InsertAsync(document);

        var documentActions = await _approvalsService.InitApprovals(document.Id, userInfo.UserId, type);

        document.Actions = documentActions.ToList();

        await _unitOfWork.SaveChangesAsync();
        
        return document;
    }
}