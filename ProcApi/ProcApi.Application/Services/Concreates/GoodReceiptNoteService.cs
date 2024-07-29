using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.PurchaseRequest.Requests;
using ProcApi.Application.DTOs.PurchaseRequest.Responses;
using ProcApi.Application.Enums;
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

public class GoodReceiptNoteService : IGoodReceiptNoteService
{
    private readonly IDocumentService _documentService;
    private readonly IGoodReceiptNoteRepository _goodReceiptNoteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public GoodReceiptNoteService(IDocumentService documentService,
        IGoodReceiptNoteRepository goodReceiptNoteRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer)
    {
        _documentService = documentService;
        _goodReceiptNoteRepository = goodReceiptNoteRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localizer = localizer;
    }

    public Task<object?> GetAllItemsAsync(int docId)
    {
        throw new NotImplementedException();
    }

    public async Task<object?> CreateGoodReceiptNoteAsync(UserInfoModel userInfo)
    {
        var document = await _documentService.CreateDocumentWithApprovalsAsync(userInfo,
            DocumentType.GoodReceiptNote,
            DocumentStatus.GoodReceiptNoteDraft);

        var goodReceiptNote = new GoodReceiptNote()
        {
            Document = document
        };

        await _goodReceiptNoteRepository.InsertAsync(goodReceiptNote);

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task<object?> GetDocumentAsync(int docId)
    {
        var document = await _goodReceiptNoteRepository.GetWithDocumentAndActionsAndItemsByDocId(docId);

        return _mapper.Map<PRResponse>(document);
    }

    public async Task<SavePRResponse> SaveGoodReceiptNoteAsync(SavePRRequest dto)
    {
        var grn = await _goodReceiptNoteRepository.GetWithDocumentAndItemsByDocId(dto.DocumentId);

        if (grn.Document.DocumentStatusId != DocumentStatus.GoodReceiptNoteDraft)
            throw new ValidationException(_localizer[LocalizationKeys.CANT_CHANGE_NON_DRAFT_DOCUMENT]);

        _mapper.Map(dto, grn);

        var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
        grn.Items = AddItems(grn.Items, itemsToAdd);

        var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
        grn.Items = UpdateItems(grn.Items, itemsToUpdate);

        var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
        grn.Items = DeleteItems(grn.Items, itemsToDelete);

        RecalculateTotalItemsPrice(grn, grn.Items);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SavePRResponse>(grn);
    }

    private ICollection<GoodReceiptNoteItem> AddItems(ICollection<GoodReceiptNoteItem> items,
        IEnumerable<CreatePRItemRequest> itemsToAdd)
    {
        foreach (var itemToAdd in itemsToAdd)
        {
            items.Add(_mapper.Map<GoodReceiptNoteItem>(itemToAdd));
        }

        return items;
    }

    private ICollection<GoodReceiptNoteItem> UpdateItems(ICollection<GoodReceiptNoteItem> items,
        IEnumerable<CreatePRItemRequest> itemsToUpdate)
    {
        foreach (var itemToUpdate in itemsToUpdate)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                _mapper.Map(itemToUpdate, item);
        }

        return items;
    }

    private ICollection<GoodReceiptNoteItem> DeleteItems(ICollection<GoodReceiptNoteItem> items,
        IEnumerable<CreatePRItemRequest> itemsToDelete)
    {
        foreach (var itemToUpdate in itemsToDelete)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                items.Remove(item);
        }

        return items;
    }

    private void RecalculateTotalItemsPrice(GoodReceiptNote document, IEnumerable<GoodReceiptNoteItem> items)
    {
        var sum = items.Sum(i => i.Quantity * i.Price);
        document.TotalItemsPrice = sum;
    }
}