using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.Data.ProcDatabase.Models;

public class ReleaseStrategy
{
    public int Id { get; set; }
    public int ActiveStatusId { get; set; }
    public DocumentStatus ActiveStatus { get; set; }
    public int AssignStatusId { get; set; }
    public DocumentStatus AssignStatus { get; set; }
    public int ActionTypeId { get; set; }
    public ActionType ActionType { get; set; }
    public int ApprovalFlowTemplateId { get; set; }
    public ApprovalFlowTemplate ApprovalFlowTemplate { get; set; }
}