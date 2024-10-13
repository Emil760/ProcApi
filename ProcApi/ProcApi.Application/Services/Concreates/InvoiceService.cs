using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Application.Enums;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
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
    private readonly IDocumentService _documentService;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IPurchaseRequestItemsRepository _purchaseRequestItemsRepository;
    private readonly IUnitOfMeasureConverterRepository _unitOfMeasureConverterRepository;
    private readonly IDocumentNumberGenerator _documentNumberGenerator;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceService(IDocumentService documentService,
        IInvoiceRepository invoiceRepository,
        IInvoiceItemRepository invoiceItemRepository,
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IUnitOfMeasureConverterRepository unitOfMeasureConverterRepository,
        IDocumentNumberGenerator documentNumberGenerator,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _documentService = documentService;
        _invoiceRepository = invoiceRepository;
        _invoiceItemRepository = invoiceItemRepository;
        _purchaseRequestItemsRepository = purchaseRequestItemsRepository;
        _unitOfMeasureConverterRepository = unitOfMeasureConverterRepository;
        _documentNumberGenerator = documentNumberGenerator;
        _localizer = localizer;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<InvoiceResponse> GetDocumentAsync(int docId)
    {
        var document = await _invoiceRepository.GetWithDocumentAndActionsAndItemsByDocId(docId);

        return _mapper.Map<InvoiceResponse>(document);
    }

    public async Task<DocumentResponseDto> CreateInvoice(UserInfoModel userInfo)
    {
        var document = await _documentService.CreateDocumentWithApprovalsAsync(userInfo,
            DocumentType.Invoice,
            DocumentStatus.InvoiceDraft);

        var invoice = new Invoice()
        {
            Document = document
        };

        await _invoiceRepository.InsertAsync(invoice);

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(
        PaginationModel model)
    {
        return await _invoiceRepository.GetUnusedPurchaseRequestItemsAsync(model);
    }

    public async Task<SaveInvoiceResponse> SaveInvoiceAsync(SaveInvoiceRequest dto)
    {
        var invoice = await _invoiceRepository.GetWithDocumentAndItemsByDocId(dto.DocumentId);

        if (invoice is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        if (invoice.Document.DocumentStatusId != DocumentStatus.InvoiceDraft)
            throw new ValidationException(_localizer[LocalizationKeys.CANT_CHANGE_NON_DRAFT_DOCUMENT]);

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

        var number = await _documentNumberGenerator.GenerateDocumentNumber(invoice.Document.Id, invoice.Document.DocumentTypeId);
        invoice.Document.Number = number;

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SaveInvoiceResponse>(invoice);
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
                throw new NotFoundException(_localizer[LocalizationKeys.ITEM_NOT_FOUND]);

            if (invoiceItem.Quantity > unusedPRItem.UnusedCount)
                throw new ValidationException(_localizer[LocalizationKeys.ITEM_COUNT_EXTENDED]);

            invoiceItem.Price = unusedPRItem.Price;
        }

        return invoiceItems;
    }

    public async Task ChangePurchaseRequestItemStatuses(int invoiceId)
    {
        var invoice = await _invoiceRepository.GetWithDocumentAndItemsByDocId(invoiceId);

        if (invoice is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        if (invoice.Document.DocumentStatusId != DocumentStatus.InvoiceApproved)
            throw new ValidationException(_localizer[LocalizationKeys.DOCUMENT_IS_NOT_APPROVED]);

        var purchaseRequestItemIds = invoice.Items.Select(ini => ini.PurchaseRequestItemId);

        var usedInvoiceItems =
            await _invoiceItemRepository.GetByPurchaseItemIdsAndStatus(
                purchaseRequestItemIds,
                DocumentStatus.InvoiceApproved);

        var purchaseRequestItems = await _purchaseRequestItemsRepository.GetByIdsAsync(purchaseRequestItemIds);

        foreach (var invoiceItem in invoice.Items)
        {
            var purchaseRequestItem = purchaseRequestItems
                .SingleOrDefault(pri => pri.Id == invoiceItem.PurchaseRequestItemId);

            if (purchaseRequestItem is null)
                throw new NotFoundException(_localizer[LocalizationKeys.ITEM_NOT_FOUND]);

            var usedCount = usedInvoiceItems
                .Where(ini => ini.PurchaseRequestItemId == invoiceItem.PurchaseRequestItemId)
                .Sum(ini => ini.Quantity);

            if (usedCount > purchaseRequestItem.Quantity)
                throw new ValidationException(_localizer[LocalizationKeys.ITEM_ALREADY_USED]);

            if (usedCount == purchaseRequestItem.Quantity)
                purchaseRequestItem.ItemStatusId = ItemStatus.FullyUsed;
            else
                purchaseRequestItem.ItemStatusId = ItemStatus.PartiallyUsed;
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ChangeUnitOfMeasureItem(ChangeUnitOfMeasureItemRequest request)
    {
        var item = await _invoiceItemRepository.GetWithUnitOfMeasureByIdAsync(request.ItemId);
        if (item is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ITEM_NOT_FOUND]);

        var rule = await _unitOfMeasureConverterRepository.GetBySourceIdAndTargetId(
            item.UnitOfMeasureId, request.UnitOfMeasureId);

        if (rule is null)
            throw new NotFoundException(_localizer[LocalizationKeys.UNIT_MEASURE_RULE_NOT_FOUND]);

        if (!rule.IsActive)
            throw new ValidationException(_localizer[LocalizationKeys.UNIT_MEASURE_RULE_IS_NOT_ACTIVE]);

        var quantity = item.Quantity / rule.Value;

        if (!item.UnitOfMeasure.CanBeDecimal && !decimal.IsInteger(quantity))
            throw new ValidationException(_localizer[LocalizationKeys.QUANTITY_MUST_BE_INTEGER]);

        item.UnitOfMeasureId = request.UnitOfMeasureId;
        item.Quantity = quantity;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<InvoiceItemResponse> GetItemAsync(int id)
    {
        var item = await _invoiceItemRepository.GetByIdAsync(id);
        if (item is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ITEM_NOT_FOUND]);

        return _mapper.Map<InvoiceItemResponse>(item);
    }

    private void RecalculateTotalItemsPrice(Invoice document,
        IEnumerable<InvoiceItem> items)
    {
        var sum = items.Sum(i => i.Quantity * i.Price);
        document.TotalItemsPrice = sum;
    }

    private ICollection<InvoiceItem> AddItems(ICollection<InvoiceItem> items,
        IEnumerable<CreateInvoiceItemRequest> itemsToAdd)
    {
        foreach (var itemToAdd in itemsToAdd)
        {
            items.Add(_mapper.Map<InvoiceItem>(itemToAdd));
        }

        return items;
    }

    private ICollection<InvoiceItem> UpdateItems(ICollection<InvoiceItem> items,
        IEnumerable<CreateInvoiceItemRequest> itemsToUpdate)
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
        IEnumerable<CreateInvoiceItemRequest> itemsToDelete)
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