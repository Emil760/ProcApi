using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.Application.DTOs.PurchaseRequestDocument.Response;

public class SavePRResponseDto : PRDto
{
    public IEnumerable<PRItemResponseDto> Items { get; set; }
    public decimal TotalItemsPrice { get; set; }
}