using ProcApi.Data.ProcDatabase.Enums;

namespace ProcApi.DTOs.Documents.Requests;

public class ActionPerformRequestDto
{
    public int DocId { get; set; }
    public ActionType ActionType { get; set; }
}