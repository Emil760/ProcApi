using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Documents.Requests;

public class ActionPerformRequest
{
    public ActionType ActionType { get; set; }
    public int DocId { get; set; }
    public string Reason { get; set; }
}