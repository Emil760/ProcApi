using ProcApi.Application.DTOs.PurchaseRequestDocument.Base;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Domain.Entities;

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