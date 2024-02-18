namespace ProcApi.Application.DTOs.UnitOfMeasure.Requests;

public class CreateUnitOfMeasureConversationRuleRequestDto
{
    public int SourceUnitOfMeasureId { get; set; }
    public int TargetUnitOfMeasureId { get; set; }
    public decimal Value { get; set; }
}