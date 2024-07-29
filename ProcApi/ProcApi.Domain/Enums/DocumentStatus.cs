namespace ProcApi.Domain.Enums;

public enum DocumentStatus
{
    #region PurchaseRequest

    PurchaseRequestDraft = 100,
    PurchaseRequestWaitingForHeadOfProcurement,
    PurchaseRequestWaitingForProcurementDirector,
    PurchaseRequestWaitingForBuyer,
    PurchaseRequestWaitingFinance,
    PurchaseRequestApproved,
    PurchaseRequestCanceled,
    PurchaseRequestRejected,

    #endregion

    #region ServiceRequest

    ServiceRequestDraft = 200,
    ServiceRequestWaitingForHeadOfProcurement,
    ServiceRequestWaitingForProcurementDirector,
    ServiceRequestWaitingForBuyer,
    ServiceRequestWaitingFinance,
    ServiceRequestApproved,
    ServiceRequestCanceled,
    ServiceRequestRejected,

    #endregion

    #region Invoices

    InvoiceDraft = 300,
    InvoiceWaitingForCoordinator,
    InvoiceWaitingForFinance,
    InvoiceWaitingForReviewer,
    InvoiceApproved,
    InvoiceRejected,
    InvoiceCanceled,

    #endregion

    #region GoodReceiptNote

    GoodReceiptNoteDraft = 400,

    #endregion

    #region GoodIssueNote

    GoodIssueNoteDraft = 500,

    #endregion
}