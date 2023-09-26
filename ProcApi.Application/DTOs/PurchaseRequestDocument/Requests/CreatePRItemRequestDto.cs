using ProcApi.Application.Enums;
using ProcApi.DTOs.PurchaseRequestDocument.Base;

namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePRItemRequestDto : PRItemDto
{
    public int Id { get; set; }
    public ActionState State { get; set; }
}