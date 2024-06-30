namespace ProcApi.Domain.Entities;

public class GoodIssueNote
{
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public ICollection<GoodIssueNoteItem> Items { get; set; }
}