using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class DropDownSource : IEntity<int>
{
    public int Id { get; set; }
    public string Key { get; set; }
    public ICollection<DropDownItem> Items { get; set; }
}