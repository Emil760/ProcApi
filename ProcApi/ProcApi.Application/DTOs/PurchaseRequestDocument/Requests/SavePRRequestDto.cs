using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;

public class SavePRRequestDto : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreatePRItemRequestDto> Items { get; set; }
}