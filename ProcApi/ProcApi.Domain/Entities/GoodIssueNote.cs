using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class GoodIssueNote : IEntity<int>
{
    public int Id { get; set; }
    public Document Document { get; set; }
    public ICollection<GoodIssueNoteItem> Items { get; set; }
}