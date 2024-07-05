using ProcApi.Application.DTOs.Invoice.Base;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class InvoiceItemProfile : CommonProfile
{
    public InvoiceItemProfile()
    {
        CreateMap<InvoiceItem, InvoiceItemResponse>();
        
        CreateMap<CreateInvoiceItemRequest, InvoiceItem>();

        CreateMap<InvoiceItemDto, InvoiceItem>().ReverseMap();
    }
}