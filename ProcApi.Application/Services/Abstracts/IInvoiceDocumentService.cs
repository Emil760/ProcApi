using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Application.Services.Abstracts;

public interface IInvoiceDocumentService
{
    Task<IEnumerable<UnusedPurchaseRequestItemsResultSet>> GetUnusedPurchaseRequestItemsAsync(PaginationModel model);
    Task<InvoiceResponseDto> CreateInvoiceAsync(CreateInvoiceRequestDto dto);
    Task<InvoiceResponseDto> UpdateInvoiceAsync(UpdateInoiceRequestDto dto);
}