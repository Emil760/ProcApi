using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Enums;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Resources;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class PurchaseRequestDocumentService : IPurchaseRequestDocumentService
    {
        private readonly IPurchaseRequestDocumentRepository _purchaseRequestDocumentRepository;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequestDocumentService(IPurchaseRequestDocumentRepository purchaseRequestDocumentRepository,
            IMapper mapper,
            IStringLocalizer<SharedResource> localizer,
            IUnitOfWork unitOfWork)
        {
            _purchaseRequestDocumentRepository = purchaseRequestDocumentRepository;
            _mapper = mapper;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
        }

        public async Task<PRResponseDto> GetDocument(int docId)
        {
            var document = await _purchaseRequestDocumentRepository.GetDocumentWithActionsAndItems(docId);

            return _mapper.Map<PRResponseDto>(document);
        }

        public async Task<SavePRResponseDto> CreateDocument(CreatePRRequestDto dto)
        {
            var purchaseRequestDocument = _mapper.Map<PurchaseRequestDocument>(dto);

            await _purchaseRequestDocumentRepository.InsertAsync(purchaseRequestDocument);

            return _mapper.Map<SavePRResponseDto>(purchaseRequestDocument);
        }

        public async Task<SavePRResponseDto> UpdateDocument(UpdatePRRequestDto dto)
        {
            var purchaseRequestDocument = await _purchaseRequestDocumentRepository.GetDocumentWithItems(dto.DocumentId);

            if (purchaseRequestDocument is null)
                throw new NotFoundException(_localizer["DocumentNotFound"]);

            _mapper.Map(dto, purchaseRequestDocument);

            var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
            purchaseRequestDocument.Items = AddItems(purchaseRequestDocument.Items, itemsToAdd);

            var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
            purchaseRequestDocument.Items = UpdateItems(purchaseRequestDocument.Items, itemsToUpdate);

            var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
            purchaseRequestDocument.Items = DeleteItems(purchaseRequestDocument.Items, itemsToDelete);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SavePRResponseDto>(purchaseRequestDocument);
        }

        private ICollection<PurchaseRequestDocumentItem> AddItems(ICollection<PurchaseRequestDocumentItem> items,
            IEnumerable<CreatePRItemRequestDto> itemsToAdd)
        {
            foreach (var itemToAdd in itemsToAdd)
            {
                items.Add(_mapper.Map<PurchaseRequestDocumentItem>(itemToAdd));
            }

            return items;
        }

        private ICollection<PurchaseRequestDocumentItem> UpdateItems(ICollection<PurchaseRequestDocumentItem> items,
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

        private ICollection<PurchaseRequestDocumentItem> DeleteItems(ICollection<PurchaseRequestDocumentItem> items,
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
    }
}