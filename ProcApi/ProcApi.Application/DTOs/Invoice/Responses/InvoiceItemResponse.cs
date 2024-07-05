using ProcApi.Application.DTOs.Invoice.Base;

namespace ProcApi.Application.DTOs.Invoice.Responses;

public class InvoiceItemResponse : InvoiceItemDto
{
    public int Id { get; set; }
}