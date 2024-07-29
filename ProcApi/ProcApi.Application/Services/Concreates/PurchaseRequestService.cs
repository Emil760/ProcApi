using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Documents.Requests;
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

public class PurchaseRequestService : IPurchaseRequestService
{
    private readonly IDocumentService _documentService;
    private readonly IApprovalsService _approvalsService;
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;
    private readonly IPurchaseRequestItemsRepository _purchaseRequestItemsRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;

    public PurchaseRequestService(IDocumentService documentService,
        IApprovalsService approvalsService,
        IPurchaseRequestRepository purchaseRequestRepository,
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork)
    {
        _documentService = documentService;
        _approvalsService = approvalsService;
        _purchaseRequestRepository = purchaseRequestRepository;
        _purchaseRequestItemsRepository = purchaseRequestItemsRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<DocumentResponseDto> CreatePurchaseRequest(UserInfoModel userInfo)
    {
        var document = await _documentService.CreateDocumentWithApprovalsAsync(userInfo,
            DocumentType.PurchaseRequest,
            DocumentStatus.PurchaseRequestDraft);

        var purchaseRequest = new PurchaseRequest()
        {
            Document = document
        };

        await _purchaseRequestRepository.InsertAsync(purchaseRequest);

        return _mapper.Map<DocumentResponseDto>(document);
    }

    public async Task AssignBuyerToItemAsync(AssignUserToItemRequest request)
    {
        var item = await _purchaseRequestItemsRepository.GetByIdAsync(request.ItemId);
        if (item is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ITEM_NOT_FOUND]);

        var user = await _userRepository.GetByIdAndRoleId(request.UserId, Roles.Buyer);
        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND_OR_NOT_IN_ROLE]);

        item.Buyer = user;

        await _approvalsService.AddMultipleApprovalToDocument(
            request.DocumentId, request.UserId, Roles.Buyer, DocumentType.PurchaseRequest);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<PRResponse> GetDocumentAsync(int docId)
    {
        var document = await _purchaseRequestRepository.GetWithDocumentAndActionsAndItemsByDocId(docId);

        return _mapper.Map<PRResponse>(document);
    }

    public async Task<SavePRResponse> SavePurchaseRequest(SavePRRequest dto)
    {
        var pr = await _purchaseRequestRepository.GetWithDocumentAndItemsByDocId(dto.DocumentId);

        if (pr.Document.DocumentStatusId != DocumentStatus.PurchaseRequestDraft)
            throw new ValidationException(_localizer[LocalizationKeys.CANT_CHANGE_NON_DRAFT_DOCUMENT]);

        _mapper.Map(dto, pr);

        var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
        pr.Items = AddItems(pr.Items, itemsToAdd);

        var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
        pr.Items = UpdateItems(pr.Items, itemsToUpdate);

        var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
        pr.Items = DeleteItems(pr.Items, itemsToDelete);

        RecalculateTotalItemsPrice(pr, pr.Items);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SavePRResponse>(pr);
    }
    
    public async Task<IEnumerable<PRItemResponse>> GetAllItemsAsync(int docId)
    {
        var items = await _purchaseRequestItemsRepository.GetAllByDocIdAsync(docId);

        return _mapper.Map<IEnumerable<PRItemResponse>>(items);
    }

    private ICollection<PurchaseRequestItem> AddItems(ICollection<PurchaseRequestItem> items,
        IEnumerable<CreatePRItemRequest> itemsToAdd)
    {
        foreach (var itemToAdd in itemsToAdd)
        {
            items.Add(_mapper.Map<PurchaseRequestItem>(itemToAdd));
        }

        return items;
    }

    private ICollection<PurchaseRequestItem> UpdateItems(ICollection<PurchaseRequestItem> items,
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

    private ICollection<PurchaseRequestItem> DeleteItems(ICollection<PurchaseRequestItem> items,
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

    private void RecalculateTotalItemsPrice(PurchaseRequest document,
        IEnumerable<PurchaseRequestItem> items)
    {
        var sum = items.Sum(i => i.Quantity * i.Price);
        document.TotalItemsPrice = sum;
    }
}