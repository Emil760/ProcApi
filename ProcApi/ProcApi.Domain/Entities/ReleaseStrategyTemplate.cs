using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class ReleaseStrategyTemplate : IEntity<int>
{
    public int Id { get; set; }
    public string FlowCodes { get; set; }
    public DocumentStatus ActiveStatusId { get; set; }
    public DocumentStatus AssignStatusId { get; set; }
    public ActionType ActionTypeId { get; set; }
    public int ApprovalFlowTemplateId { get; set; }
    public ApprovalFlowTemplate ApprovalFlowTemplate { get; set; }
}