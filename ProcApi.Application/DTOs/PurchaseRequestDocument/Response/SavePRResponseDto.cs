using ProcApi.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public class SavePRResponseDto : PRDto
{
    public IEnumerable<PRItemResponseDto> Items { get; set; }
}