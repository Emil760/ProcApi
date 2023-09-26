using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class ReleaseStrategy
{
    public int Id { get; set; }
    public DocumentStatus ActiveStatusId { get; set; }
    public DocumentStatus AssignStatusId { get; set; }
    public ActionType ActionTypeId { get; set; }
    public int ApprovalFlowTemplateId { get; set; }
    public ApprovalFlowTemplate ApprovalFlowTemplate { get; set; }
}