using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Application.Enums;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
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
            var document = _mapper.Map<PurchaseRequestDocument>(dto);

            RecalculateTotalItemsPrice(document, document.Items);

            await _purchaseRequestDocumentRepository.InsertAsync(document);

            return _mapper.Map<SavePRResponseDto>(document);
        }

        public async Task<SavePRResponseDto> UpdateDocument(UpdatePRRequestDto dto)
        {
            var document = await _purchaseRequestDocumentRepository.GetDocumentWithItems(dto.DocumentId);

            if (document is null)
                throw new NotFoundException(_localizer["DocumentNotFound"]);

            _mapper.Map(dto, document);

            var itemsToAdd = dto.Items.Where(i => i.State == ActionState.Added);
            document.Items = AddItems(document.Items, itemsToAdd);

            var itemsToUpdate = dto.Items.Where(i => i.State == ActionState.Updated);
            document.Items = UpdateItems(document.Items, itemsToUpdate);

            var itemsToDelete = dto.Items.Where(i => i.State == ActionState.Deleted);
            document.Items = DeleteItems(document.Items, itemsToDelete);
            
            RecalculateTotalItemsPrice(document, document.Items);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SavePRResponseDto>(document);
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

        private void RecalculateTotalItemsPrice(PurchaseRequestDocument document,
            IEnumerable<PurchaseRequestDocumentItem> items)
        {
            var sum = items.Sum(i => i.Quantity * i.Price);
            document.TotalItemsPrice = sum;
        }
    }
}