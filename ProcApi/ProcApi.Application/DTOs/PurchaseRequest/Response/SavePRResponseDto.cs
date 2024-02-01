using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Response;

public class SavePRResponseDto : PRDto
{
    public IEnumerable<PRItemResponseDto> Items { get; set; }
    public decimal TotalItemsPrice { get; set; }
}