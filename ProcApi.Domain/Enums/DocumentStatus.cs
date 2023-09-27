namespace ProcApi.Domain.Enums;

public enum DocumentStatus
{
    #region PurchaseRequest

    PurchaseRequestDraft = 100,
    PurchaseRequestWaitingForBuyer,
    PurchaseRequestWaitingFinance,
    PurchaseRequestWaitingForHeadOfProcurement,
    PurchaseRequestApproved,
    PurchaseRequestCanceled,
    PurchaseRequestRejected,

    #endregion

    #region ServiceRequest

    ServiceRequestDraft = 200,
    ServiceRequestWaitingForBuyer,
    ServiceRequestWaitingFinance,
    ServiceRequestWaitingForHeadOfProcurement,
    ServiceRequestApproved,
    ServiceRequestCanceled,
    ServiceRequestRejected,

    #endregion

    #region Invoices

    InvoiceDraft = 300,
    InvoiceWaitingForReviewer,
    InvoiceWaitingForFinance,
    InvoiceApproved

    #endregion
}