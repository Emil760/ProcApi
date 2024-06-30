namespace ProcApi.Domain.Entities;

public class GoodIssueNoteItem
{
    public int Id { get; set; }
    public int GoodIssueNoteId { get; set; }
    public GoodIssueNote GoodIssueNote { get; set; }
}