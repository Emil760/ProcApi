namespace ProcApi.Data.ProcDatabase.Enums;

public enum DocumentStatus
{
    #region Requests
    PurchaseRequestDraft = 1,

    ServiceRequestDraft,
    #endregion

    #region Invoices
    PostPaymentInvoiceDraft,

    DownPaymentInvoiceDraft
    #endregion
}