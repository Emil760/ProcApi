using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Application.DTOs.Invoice.Requests;
using ProcApi.Application.DTOs.Invoice.Responses;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Application.Services.Abstracts;

public interface IInvoiceService
{
    Task<InvoiceResponse> GetDocumentAsync(int docId);
    Task<DocumentResponseDto> CreateInvoice(UserInfoModel userInfo);
    Task<IEnumerable<UnusedPRItemInfoResultSet>> GetUnusedPurchaseRequestItemsAsync(PaginationModel model);
    Task<SaveInvoiceResponse> SaveInvoiceAsync(SaveInvoiceRequest dto);
    Task ChangePurchaseRequestItemStatuses(int invoiceId);
    Task ChangeUnitOfMeasureItem(ChangeUnitOfMeasureItemRequest request);
    Task<InvoiceItemResponse> GetItemAsync(int id);
}