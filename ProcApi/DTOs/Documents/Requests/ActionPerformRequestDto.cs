using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents.Requests;

public class ActionPerformRequestDto
{
    public ActionType ActionType { get; set; }
    public int DocId { get; set; }
    public string Reason { get; set; }
}