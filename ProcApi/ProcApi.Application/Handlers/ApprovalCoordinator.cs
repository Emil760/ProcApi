using Microsoft.AspNetCore.Http;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Application.Handlers;

public class ApprovalCoordinator : IApprovalCoordinator
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IDocumentRepository _documentRepository;

    public ApprovalCoordinator(IHttpContextAccessor contextAccessor,
        IDocumentRepository documentRepository)
    {
        _contextAccessor = contextAccessor;
        _documentRepository = documentRepository;
    }

    public async Task PerformAction(ActionPerformRequest dto, UserInfoModel userInfo)
    {
        var documentType = await _documentRepository.GetTypeAsync(dto.DocId);
        var typeName = $"ProcApi.Application.Handlers.{documentType}.{documentType}{dto.ActionType}Handler";
        var type = Type.GetType(typeName);

        if (type is null)
            throw new Exception("System error");

        var service = (IActionHandler)_contextAccessor.HttpContext?.RequestServices.GetService(type)!;

        await service.PerformAction(dto, userInfo.UserId);
    }
}