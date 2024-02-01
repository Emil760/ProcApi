using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Requests;

public class SavePRRequestDto : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreatePRItemRequestDto> Items { get; set; }
}