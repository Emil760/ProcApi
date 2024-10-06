using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.ReservedItem.Requests;
using ProcApi.Application.DTOs.ReservedItem.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
{
    public class ReservedItemService : IReservedItemService
    {
        private readonly IReservedItemRepository _reservedItemRepository;
        private readonly IGoodReceiptNoteItemRepository _goodReceiptNoteItemRepository;
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ReservedItemService(IReservedItemRepository reservedItemRepository,
            IStringLocalizer<SharedResource> localizer,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IGoodReceiptNoteItemRepository goodReceiptNoteItemRepository,
            IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            _reservedItemRepository = reservedItemRepository;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _goodReceiptNoteItemRepository = goodReceiptNoteItemRepository;
            _unitOfMeasureRepository = unitOfMeasureRepository;
        }

        public async Task ActivateReservedItemAsync(ActivateReservedItemRequest request)
        {
            var entity = await _reservedItemRepository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(_localizer[LocalizationKeys.RESERVED_ITEM_NOT_FOUND]);

            entity.IsActive = request.IsActive;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReserveItemResponse>> GetItemsAsync(PaginationModel request)
        {
            var paginated = await _reservedItemRepository.GetWithGoodReceiptNoteAndMaterialPaginated(request);

            _httpContextAccessor.HttpContext!.Response.Headers.Add(HeaderKeys.XPagination, paginated.ToString());

            return _mapper.Map<IEnumerable<ReserveItemResponse>>(paginated.ResultSet);
        }

        public async Task<IEnumerable<ItemForReservationResponse>> GetItemsForReservationAsync(PaginationModel request)
        {
            var paginated = await _goodReceiptNoteItemRepository.GetNotUsedItemsWithMaterialAndUnitOfMeasurePaginated(request);

            _httpContextAccessor.HttpContext!.Response.Headers.Add(HeaderKeys.XPagination, paginated.ToString());

            return _mapper.Map<IEnumerable<ItemForReservationResponse>>(paginated.ResultSet);
        }

        public async Task<ReserveItemResponse> SaveReservedItemAsync(SaveReservedItemRequest request)
        {
            var reserveItem = _mapper.Map<ReservedItem>(request);

            if (!await _goodReceiptNoteItemRepository.ExistsById(reserveItem.GoodReceiptNoteItemId))
                throw new NotFoundException(_localizer[LocalizationKeys.GOOD_RECEIPT_NOTE_ITEM_NOT_FOUND]);

            if (!await _unitOfMeasureRepository.ExistsById(reserveItem.UnitOfMeasureId))
                throw new NotFoundException(_localizer[LocalizationKeys.UNIT_OF_MEASURE_NOT_FOUND]);

            await _reservedItemRepository.InsertAsync(reserveItem);

            return _mapper.Map<ReserveItemResponse>(reserveItem);
        }

        public Task UpdateReservedItemAsync(UpdateReservedItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
