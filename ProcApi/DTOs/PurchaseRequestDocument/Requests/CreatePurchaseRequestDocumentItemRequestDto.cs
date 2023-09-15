using ProcApi.DTOs.PurchaseRequestDocument.Base;
using ProcApi.Enums;

namespace ProcApi.DTOs.PurchaseRequestDocument.Requests;

public class CreatePurchaseRequestDocumentItemRequestDto : PurchaseRequestDocumentItemDto
{
    public ActionState State { get; set; }
}