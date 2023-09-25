using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.PurchaseRequestDocument.Base;
using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Mappers;

public class PurchaseRequestItemProfile : CommonProfile
{
    public PurchaseRequestItemProfile()
    {
        CreateMap<PurchaseRequestDocumentItem, PRItemResponseDto>();

        CreateMap<PRItemDto, PurchaseRequestDocumentItem>().ReverseMap();
    }
}