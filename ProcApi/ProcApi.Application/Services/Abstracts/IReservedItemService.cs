using ProcApi.Application.DTOs.ReservedItem.Requests;
using ProcApi.Application.DTOs.ReservedItem.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts
{
    public interface IReservedItemService
    {
        Task ActivateReservedItemAsync(ActivateReservedItemRequest request);
        Task<IEnumerable<ReserveItemResponse>> GetItemsAsync(PaginationModel request);
        Task<IEnumerable<ItemForReservationResponse>> GetItemsForReservationAsync(PaginationModel request);
        Task<ReserveItemResponse> SaveReservedItemAsync(SaveReservedItemRequest request);
        Task UpdateReservedItemAsync(UpdateReservedItemRequest request);
    }
}
