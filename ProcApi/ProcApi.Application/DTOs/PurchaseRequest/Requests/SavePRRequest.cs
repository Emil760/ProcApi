using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Requests;

public class SavePRRequest : PRDto
{
    public int DocumentId { get; set; }
    public IEnumerable<CreatePRItemRequest> Items { get; set; }
}