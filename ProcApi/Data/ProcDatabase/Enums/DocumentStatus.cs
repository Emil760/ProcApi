namespace ProcApi.Data.ProcDatabase.Enums;

public enum DocumentStatus
{
    #region Requests
    PurchaseRequestDraft,

    ServiceRequestDraft,
    #endregion

    #region Invoices
    PostPaymentInvoiceDraft,

    DownPaymentInvoiceDraft
    #endregion
}