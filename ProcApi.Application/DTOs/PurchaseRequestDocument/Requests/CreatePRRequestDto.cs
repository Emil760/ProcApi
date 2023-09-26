using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;

public class CreatePRRequestDto : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<PRItemDto> Items { get; set; }
}