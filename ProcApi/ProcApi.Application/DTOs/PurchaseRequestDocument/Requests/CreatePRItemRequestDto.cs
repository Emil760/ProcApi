using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;
using ProcApi.Application.Enums;

namespace ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;

public class CreatePRItemRequestDto : PRItemDto
{
    public int Id { get; set; }
    public ActionState State { get; set; }
}