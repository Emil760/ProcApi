using ProcApi.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class UpdatePRRequestDto : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreatePRItemRequestDto> Items { get; set; }
}