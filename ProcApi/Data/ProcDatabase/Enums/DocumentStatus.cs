namespace ProcApi.Data.ProcDatabase.Enums;

public enum DocumentStatus
{
    #region Requests
    PurchaseRequestDraft = 100,
    PurchaseRequestWaitingFinance = 101,
    PurchaseRequestApproved = 102,
    PurchaseRequestCanceled = 103,
    PurchaseRequestRejected = 104,
    PurchaseRequestWaitingForHeadOfProcurement = 105,

    ServiceRequestDraft = 200,
    ServiceRequestWaitingFinance = 201,
    ServiceRequestApproved = 202,
    ServiceRequestCanceled = 203,
    ServiceRequestRejected = 204,
    ServiceRequestWaitingForHeadOfProcurement = 205,
    #endregion

    #region Invoices
    PostPaymentInvoiceDraft,

    DownPaymentInvoiceDraft
    #endregion
}