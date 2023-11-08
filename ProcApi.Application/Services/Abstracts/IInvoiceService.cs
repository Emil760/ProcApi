using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Application.Services.Abstracts;

public interface IInvoiceService
{
    Task<InvoiceResponseDto> GetDocumentAsync(int docId);
    Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(PaginationModel model);
    Task<SaveInvoiceResponseDto> SaveInvoiceAsync(SaveInvoiceRequestDto dto);
    Task ChangePurchaseRequestItemStatuses(int invoiceId);
}