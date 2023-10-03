using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Application.Enums;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class PurchaseRequestService : IPurchaseRequestService
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseRequestService(IPurchaseRequestRepository purchaseRequestRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
        _mapper = mapper;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<PRResponseDto> GetDocumentAsync(int docId)
    {
        var document = await _purchaseRequestRepository.GetWithDocumentAndActionsAndItemsByDocId(docId);

        return _mapper.Map<PRResponseDto>(document);
    }

    public async Task<SavePRResponseDto> SavePurchaseRequest(SavePRRequestDto dto)
    {
        var pr = await _purchaseRequestRepository.GetWithDocumentAndItemsByDocId(dto.DocumentId);

        if (pr is null)
            return await CreateDocument(dto);
        
        return await UpdateDocument(pr, dto);
    }

    private async Task<SavePRResponseDto> CreateDocument(SavePRRequestDto dto)
    {
        var document = _mapper.Map<PurchaseRequest>(dto);

        RecalculateTotalItemsPrice(document, document.Items);

        await _purchaseRequestRepository.InsertAsync(document);

        return _mapper.Map<SavePRResponseDto>(document);
    }

    private async Task<SavePRResponseDto> UpdateDocument(PurchaseRequest pr, SavePRRequestDto dto)
    {
        if (pr.Document.StatusId != DocumentStatus.PurchaseRequestDraft)
            throw new ValidationException(_localizer["CantChangeNonDraftDocument"]);

        _mapper.Map(dto, pr);

        var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
        pr.Items = AddItems(pr.Items, itemsToAdd);

        var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
        pr.Items = UpdateItems(pr.Items, itemsToUpdate);

        var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
        pr.Items = DeleteItems(pr.Items, itemsToDelete);

        RecalculateTotalItemsPrice(pr, pr.Items);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SavePRResponseDto>(pr);
    }

    private ICollection<PurchaseRequestItem> AddItems(ICollection<PurchaseRequestItem> items,
        IEnumerable<CreatePRItemRequestDto> itemsToAdd)
    {
        foreach (var itemToAdd in itemsToAdd)
        {
            items.Add(_mapper.Map<PurchaseRequestItem>(itemToAdd));
        }

        return items;
    }

    private ICollection<PurchaseRequestItem> UpdateItems(ICollection<PurchaseRequestItem> items,
        IEnumerable<CreatePRItemRequestDto> itemsToUpdate)
    {
        foreach (var itemToUpdate in itemsToUpdate)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                _mapper.Map(itemToUpdate, item);
        }

        return items;
    }

    private ICollection<PurchaseRequestItem> DeleteItems(ICollection<PurchaseRequestItem> items,
        IEnumerable<CreatePRItemRequestDto> itemsToDelete)
    {
        foreach (var itemToUpdate in itemsToDelete)
        {
            var item = items.SingleOrDefault(i => i.Id == itemToUpdate.Id);
            if (item != null)
                items.Remove(item);
        }

        return items;
    }

    private void RecalculateTotalItemsPrice(PurchaseRequest document,
        IEnumerable<PurchaseRequestItem> items)
    {
        var sum = items.Sum(i => i.Quantity * i.Price);
        document.TotalItemsPrice = sum;
    }
}