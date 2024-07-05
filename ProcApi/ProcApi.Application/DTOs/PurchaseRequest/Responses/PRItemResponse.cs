using ProcApi.Application.DTOs.PurchaseRequest.Base;

namespace ProcApi.Application.DTOs.PurchaseRequest.Responses;

public class PRItemResponse : PRItemDto
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public string BuyerName { get; set; }
}