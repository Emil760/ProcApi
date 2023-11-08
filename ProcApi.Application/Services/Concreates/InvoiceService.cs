﻿using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Application.Enums;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IPurchaseRequestItemsRepository _purchaseRequestItemsRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IInvoiceRepository invoiceRepository,
        IInvoiceItemRepository invoiceItemRepository,
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _invoiceItemRepository = invoiceItemRepository;
        _purchaseRequestItemsRepository = purchaseRequestItemsRepository;
        _localizer = localizer;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<InvoiceResponseDto> GetDocumentAsync(int docId)
    {
        var document = await _invoiceRepository.GetWithDocumentAndActionsAndItemsByDocId(docId);

        return _mapper.Map<InvoiceResponseDto>(document);
    }

    public async Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model)
    {
        return await _invoiceRepository.GetUnusedPurchaseRequestItemsAsync(model);
    }

    public async Task<SaveInvoiceResponseDto> SaveInvoiceAsync(SaveInvoiceRequestDto dto)
    {
        var invoice = await _invoiceRepository.GetWithDocumentAndItemsByDocId(dto.DocumentId);

        if (invoice is null)
            return await CreateInvoiceAsync(dto);

        return await UpdateInvoiceAsync(invoice, dto);
    }

    private async Task<SaveInvoiceResponseDto> CreateInvoiceAsync(SaveInvoiceRequestDto dto)
    {
        var invoice = _mapper.Map<Invoice>(dto);
        invoice.Items = _mapper.Map<ICollection<InvoiceItem>>(dto.Items);

        var prItemIds = dto.Items.Select(i => i.PurchaseRequestItemId);

        invoice.Items = (ICollection<InvoiceItem>)await CheckAndApplyPriceItems(invoice.Items, prItemIds);

        RecalculateTotalItemsPrice(invoice, invoice.Items);

        await _invoiceRepository.InsertAsync(invoice);

        return _mapper.Map<SaveInvoiceResponseDto>(invoice);
    }

    private async Task<SaveInvoiceResponseDto> UpdateInvoiceAsync(Invoice invoice, SaveInvoiceRequestDto dto)
    {
        if (invoice.Document.StatusId != DocumentStatus.InvoiceDraft)
            throw new ValidationException(_localizer["CantChangeNonDraftDocument"]);

        _mapper.Map(dto, invoice);

        var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
        invoice.Items = AddItems(invoice.Items, itemsToAdd);

        var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
        invoice.Items = UpdateItems(invoice.Items, itemsToUpdate);

        var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
        invoice.Items = DeleteItems(invoice.Items, itemsToDelete);

        var prItemIds = dto.Items.Select(i => i.PurchaseRequestItemId);

        invoice.Items = (ICollection<InvoiceItem>)await CheckAndApplyPriceItems(invoice.Items, prItemIds);

        RecalculateTotalItemsPrice(invoice, invoice.Items);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SaveInvoiceResponseDto>(invoice);
    }

    private async Task<IEnumerable<InvoiceItem>> CheckAndApplyPriceItems(
        IEnumerable<InvoiceItem> invoiceItems,
        IEnumerable<int> prItemIds)
    {
        var unusedPRItems =
            await _invoiceRepository.GetUnusedPurchaseRequestItemsByIdsAsync(prItemIds.ToArray());

        foreach (var invoiceItem in invoiceItems)
        {
            var unusedPRItem = unusedPRItems
                .SingleOrDefault(i => i.PurchaseRequestItemId == invoiceItem.PurchaseRequestItemId);

            if (unusedPRItem is null)
                throw new NotFoundException(_localizer["ItemNotFound"]);

            invoiceItem.Price = unusedPRItem.Price;
        }

        return invoiceItems;
    }

    public async Task ChangePurchaseRequestItemStatuses(int invoiceId)
    {
        var invoice = await _invoiceRepository.GetWithDocumentAndItemsByDocId(invoiceId);

        if (invoice is null)
            throw new NotFoundException(_localizer["DocumentNotFound"]);

        if (invoice.Document.StatusId != DocumentStatus.InvoiceApproved)
            throw new ValidationException(_localizer["DocumentIsNotApproved"]);

        var purchaseRequestItemIds = invoice.Items.Select(ini => ini.PurchaseRequestItemId);

        var usedInvoiceItems =
            await _invoiceItemRepository.GetByPurchaseItemIdsAndStatus(
                purchaseRequestItemIds,
                DocumentStatus.InvoiceApproved);

        var purchaseRequestItems = await _purchaseRequestItemsRepository.GetByIds(purchaseRequestItemIds);

        foreach (var invoiceItem in invoice.Items)
        {
            var purchaseRequestItem = purchaseRequestItems
                .SingleOrDefault(pri => pri.PurchaseRequestId == invoiceItem.PurchaseRequestItemId);

            if (purchaseRequestItem is null)
                throw new NotFoundException(_localizer["ItemNotFound"]);

            var usedCount = usedInvoiceItems
                .Where(ini => ini.PurchaseRequestItemId == invoiceItem.PurchaseRequestItemId)
                .Sum(ini => ini.Quantity);

            if (usedCount > purchaseRequestItem.Quantity)
                throw new ValidationException(_localizer["ItemAlreadyUsed"]);

            if (usedCount == purchaseRequestItem.Quantity)
                purchaseRequestItem.ItemStatusId = ItemStatus.FullyUsed;
            else
                purchaseRequestItem.ItemStatusId = ItemStatus.PartiallyUsed;
        }

        await _unitOfWork.SaveChangesAsync();
    }

    private void RecalculateTotalItemsPrice(Invoice document,
        IEnumerable<InvoiceItem> items)
    {
        var sum = items.Sum(i => i.Quantity * i.Price);
        document.TotalItemsPrice = sum;
    }

    private ICollection<InvoiceItem> AddItems(ICollection<InvoiceItem> items,
        IEnumerable<CreateInvoiceItemRequestDto> itemsToAdd)
    {
        foreach (var itemToAdd in itemsToAdd)
        {
            items.Add(_mapper.Map<InvoiceItem>(itemToAdd));
        }

        return items;
    }

    private ICollection<InvoiceItem> UpdateItems(ICollection<InvoiceItem> items,
        IEnumerable<CreateInvoiceItemRequestDto> itemsToUpdate)
    {
        foreach (var itemToUpdate in itemsToUpdate)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                _mapper.Map(itemToUpdate, item);
        }

        return items;
    }

    private ICollection<InvoiceItem> DeleteItems(ICollection<InvoiceItem> items,
        IEnumerable<CreateInvoiceItemRequestDto> itemsToDelete)
    {
        foreach (var itemToUpdate in itemsToDelete)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                items.Remove(item);
        }

        return items;
    }
}