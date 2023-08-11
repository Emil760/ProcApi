using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents;

public class ActionPerformDto
{
    public int DocId { get; set; }
    public ActionType ActionType { get; set; }
}