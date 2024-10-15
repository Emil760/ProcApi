using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DocumentService : IDocumentService
{
    private readonly IApprovalsService _approvalsService;
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentNumberPatterRepository _documentNumberPatterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public DocumentService(IApprovalsService approvalsService,
        IDocumentRepository documentRepository,
        IDocumentNumberPatterRepository documentNumberPatterRepository,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer)
    {
        _approvalsService = approvalsService;
        _documentRepository = documentRepository;
        _documentNumberPatterRepository = documentNumberPatterRepository;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
    }

    public async Task<Document> CreateDocumentWithApprovalsAsync(
        UserInfoModel userInfo,
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

        var documentActions = await _approvalsService.InitApprovals(userInfo.UserId, type);

        document.Actions = documentActions.ToList();

        var documentNumberPatter = await _documentNumberPatterRepository.GetActiveByDocumentType(type);
        if (documentNumberPatter is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ACTIVE_DOCUMENT_NUMBER_PATTERN_NOT_FOUND]);

        document.DocumentNumberPattern = documentNumberPatter;

        await _documentRepository.InsertAsync(document);

        return document;
    }
}