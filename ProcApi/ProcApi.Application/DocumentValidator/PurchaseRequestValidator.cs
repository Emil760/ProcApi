using Microsoft.Extensions.Localization;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.DocumentValidator;

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
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        _purchaseRequest = document;
    }

    public async Task<string?> CheckEmptyItemsAsync()
    {
        if (!_purchaseRequest.Items.Any())
            return _localizer[LocalizationKeys.EMPTY_ITEMS];

        return null;
    }
}