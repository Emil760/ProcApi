using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Responses;

public class SavePRResponse : PRDto
{
    public string Number { get; set; }
    public IEnumerable<PRItemResponse> Items { get; set; }
    public decimal TotalItemsPrice { get; set; }
}