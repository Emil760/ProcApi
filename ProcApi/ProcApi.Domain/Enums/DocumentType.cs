using System.ComponentModel;

namespace ProcApi.Domain.Enums;

public enum DocumentType
{
    [Description("PR")]
    PurchaseRequest = 1,
    [Description("SR")]
    ServiceRequest,
    [Description("INV")]
    Invoice,
    [Description("GRN")]
    GoodReceiptNote,
    [Description("GIN")]
    GoodIssueNote
}