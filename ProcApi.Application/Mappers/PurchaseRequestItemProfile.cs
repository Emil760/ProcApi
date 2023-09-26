using ProcApi.Domain.Entities;
using ProcApi.DTOs.PurchaseRequestDocument.Base;
using ProcApi.DTOs.PurchaseRequestDocument.Response;

namespace ProcApi.Application.Mappers
{
    public class PurchaseRequestItemProfile : CommonProfile
    {
        public PurchaseRequestItemProfile()
        {
            CreateMap<PurchaseRequestDocumentItem, PRItemResponseDto>();

            CreateMap<PRItemDto, PurchaseRequestDocumentItem>().ReverseMap();
        }
    }
}