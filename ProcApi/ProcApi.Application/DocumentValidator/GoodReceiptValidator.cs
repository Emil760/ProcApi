using Microsoft.Extensions.Localization;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.DocumentValidator;

public class GoodReceiptValidator : IDocumentValidator
{
    private readonly IGoodReceiptNoteRepository _goodReceiptNoteRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;

    private GoodReceiptNote _grn;
    
    public GoodReceiptValidator(IGoodReceiptNoteRepository goodReceiptNoteRepository,
        IStringLocalizer<SharedResource> localizer)
    {
        _goodReceiptNoteRepository = goodReceiptNoteRepository;
        _localizer = localizer;
    }
    
    public async Task InitAsync(int documentId)
    {
        var document = await _goodReceiptNoteRepository.GetByIdAsync(documentId);
        if (document is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        _grn = document;
    }
}