﻿using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class InvoiceValidator : IDocumentValidator
{
    private Invoice _invoice;
    private readonly IStringLocalizer<SharedResource> _localizer;

    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceValidator(IInvoiceRepository invoiceRepository,
        IStringLocalizer<SharedResource> localizer)
    {
        _invoiceRepository = invoiceRepository;
        _localizer = localizer;
    }

    public async Task InitAsync(int documentId)
    {
        var document = await _invoiceRepository.GetWithDocumentAndItemsByDocId(documentId);
        if (document is null)
            throw new NotFoundException(_localizer["DocumentNotFound"]);

        _invoice = document;
    }

    public async Task<string?> CheckEmptyItemsAsync()
    {
        return null;
    }
}