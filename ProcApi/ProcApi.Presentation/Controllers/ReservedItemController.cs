using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.DTOs.ReservedItem.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Models;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservedItemController : BaseController
    {
        private readonly IReservedItemService _reservedItemService;

        public ReservedItemController(IReservedItemService reservedItemService)
        {
            _reservedItemService = reservedItemService;
        }

        [HttpGet("Items")]
        public async Task<IActionResult> GetItemsAsync(PaginationModel request)
        {
            return Ok(await _reservedItemService.GetItemsAsync(request));
        }

        [HttpGet("GetItemsForReservation")]
        public async Task<IActionResult> GetItemsForReservationAsync(PaginationModel request)
        {
            return Ok(await _reservedItemService.GetItemsForReservationAsync(request));
        }

        [HttpPost("ReserveItem")]
        public async Task<IActionResult> SaveReservedItemAsync(SaveReservedItemRequest request)
        {
            return Ok(await _reservedItemService.SaveReservedItemAsync(request));
        }

        [HttpPut("ReserveItem")]
        public async Task<IActionResult> UpdateReservedItemAsync(UpdateReservedItemRequest request)
        {
            await _reservedItemService.UpdateReservedItemAsync(request);
            return Ok();
        }

        [HttpPut("ActivateReservedItem")]
        public async Task<IActionResult> ActivateReservedItemAsync(ActivateReservedItemRequest request)
        {
            await _reservedItemService.ActivateReservedItemAsync(request);
            return Ok();
        }
    }
}
