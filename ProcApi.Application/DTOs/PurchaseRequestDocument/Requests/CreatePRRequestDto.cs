using ProcApi.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePRRequestDto : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<PRItemDto> Items { get; set; }
}