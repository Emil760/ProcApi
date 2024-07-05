namespace ProcApi.Application.DTOs.UnitOfMeasure.Requests;

public class CreateUnitOfMeasureConversationRuleRequest
{
    public int SourceUnitOfMeasureId { get; set; }
    public int TargetUnitOfMeasureId { get; set; }
    public decimal Value { get; set; }
}