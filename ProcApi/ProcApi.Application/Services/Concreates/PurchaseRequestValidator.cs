using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class PurchaseRequestValidator : IDocumentValidator
{
    private PurchaseRequest _purchaseRequest;
    private readonly IStringLocalizer<SharedResource> _localizer;

    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public PurchaseRequestValidator(IPurchaseRequestRepository purchaseRequestRepository,
        IStringLocalizer<SharedResource> localizer)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
        _localizer = localizer;
    }

    public async Task InitAsync(int documentId)
    {
        var document = await _purchaseRequestRepository.GetWithDocumentAndItemsByDocId(documentId);
        if (document is null)
            throw new NotFoundException(_localizer["DocumentNotFound"]);

        _purchaseRequest = document;
    }

    public async Task<string?> CheckEmptyItemsAsync()
    {
        if (!_purchaseRequest.Items.Any())
            return _localizer["EmptyItems"];

        return null;
    }
}