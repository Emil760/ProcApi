namespace ProcApi.Domain.Enums;

public enum DocumentStatus
{
    #region Requests
    PurchaseRequestDraft = 100,
    PurchaseRequestWaitingForBuyer = 101,
    PurchaseRequestWaitingFinance = 102,
    PurchaseRequestWaitingForHeadOfProcurement = 103,
    PurchaseRequestApproved = 104,
    PurchaseRequestCanceled = 105,
    PurchaseRequestRejected = 106,

    ServiceRequestDraft = 200,
    ServiceRequestWaitingForBuyer = 201,
    ServiceRequestWaitingFinance = 202,
    ServiceRequestWaitingForHeadOfProcurement = 203,
    ServiceRequestApproved = 204,
    ServiceRequestCanceled = 205,
    ServiceRequestRejected = 206,
    #endregion

    #region Invoices
    PostPaymentInvoiceDraft,

    DownPaymentInvoiceDraft
    #endregion
}