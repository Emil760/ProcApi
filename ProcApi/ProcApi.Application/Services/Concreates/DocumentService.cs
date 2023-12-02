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

    public DocumentService(IApprovalsService approvalsService,
        IDocumentRepository documentRepository)
    {
        _approvalsService = approvalsService;
        _documentRepository = documentRepository;
    }

    public async Task<Document> CreateDocumentWithApprovalsAsync(UserInfoModel userInfo,
        DocumentType type,
        DocumentStatus status)
    {
        var document = new Document
        {
            CreatedById = userInfo.UserId,
            TypeId = type,
            StatusId = status,
            CreatedOn = DateTime.Now
        };

        var documentActions =
            await _approvalsService.InitApprovals(userInfo.UserId, type);

        document.Actions = documentActions.ToList();

        await _documentRepository.InsertAsync(document);

        return document;
    }
}